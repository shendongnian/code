    // USE Class Like this
    Scripts.CreateDatabase("Connectionstring")
    
    //Class
    static class Scripts
        {
    
            static bool CreateDatabase(string Connectionstr)
            {
                bool result =false;
    
                  SqlConnection Conn = new SqlConnection(Connectionstr); // pass connection string and user must have the permission to create a database,
    
                  string Query = "CREATE DATABASE Exampledatabase ";
                    SqlCommand Command = new SqlCommand(Query, Conn);
                    try
                    {
                        Conn .Open();
                        Command.ExecuteNonQuery();
                        result =true;
                    }
                    catch (System.Exception ex)
                    {
                        result =false;
                    }
                    finally
                    {
                        if (Conn.State == ConnectionState.Open)
                        {
                            Conn.Close();
                        }
                    }
                return result;
            }
    
        }
