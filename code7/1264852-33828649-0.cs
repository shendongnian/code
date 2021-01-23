    try
                    {
                        comm.ExecuteNonQuery();
                    }
                    catch(MySql.Data.MySqlClient.MySqlException mySqlEx)
                    {
                        Console.WriteLine("Duplicate entry found");
                    }  
