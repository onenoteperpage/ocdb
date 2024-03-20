using Oracle.ManagedDataAccess.Client;

namespace ocdb
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "User Id=dbadmin;Password=db_password;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=rds_hostname.rds.amazonaws.com)(PORT=1521)))(CONNECT_Data=(SID=ORCL)));";

            string sql = @"SELECT username FROM dba_users";

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand(sql, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("List of usernames:");
                        Console.WriteLine("-------------------");

                        while (reader.Read())
                        {
                            string username = reader.GetString(0);
                            Console.WriteLine(username);
                        }
                    }
                }
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
