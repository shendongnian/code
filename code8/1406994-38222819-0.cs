    namespace Test
    {
        using System;
        using System.Data;
        using System.Data.SqlClient;
    
        public class Program
        {
            public static int Main(string[] args)
            {
                if (args.Length != 2)
                {
                    Usage();
                    return 1;
                }
    
                var conn = args[0];
                var sqlText = args[1];
                ShowSqlErrorsAndInfo(conn, sqlText);
    
                return 0;
            }
    
            private static void Usage()
            {
                Console.WriteLine("Usage: sqlServerConnectionString sqlCommand");
                Console.WriteLine("");
                Console.WriteLine("   example:  \"Data Source=.;Integrated Security=true\" \"DBCC CHECKDB\"");
            }
    
            public static void ShowSqlErrorsAndInfo(string connectionString, string query)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.StateChange += OnStateChange;
                    connection.InfoMessage += OnInfoMessage;
    
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        command.Connection.Open();
                        Console.WriteLine("Command execution starting.");
                        SqlDataReader dr = command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            Console.WriteLine("Rows returned.");
                            while (dr.Read())
                            {
                                for (int idx = 0; idx < dr.FieldCount; idx++)
                                {
                                    Console.Write("{0} ", dr[idx].ToString());
                                }
    
                                Console.WriteLine();
                            }
                        }
    
                        Console.WriteLine("Command execution complete.");
                    }
                    catch (SqlException ex)
                    {
                        DisplaySqlErrors(ex);
                    }
                    finally
                    {
                        command.Connection.Close();
                    }
                }
            }
    
            private static void DisplaySqlErrors(SqlException exception)
            {
                foreach (SqlError err in exception.Errors)
                {
                    Console.WriteLine("ERROR: {0}", err.Message);
                }
            }
    
            private static void OnInfoMessage(object sender, SqlInfoMessageEventArgs e)
            {
                foreach (SqlError info in e.Errors)
                {
                    Console.WriteLine("INFO: {0}", info.Message);
                }
            }
    
            private static void OnStateChange(object sender, StateChangeEventArgs e)
            {
                Console.WriteLine("Connection state changed: {0} => {1}", e.OriginalState, e.CurrentState);
            }
        }
    }
