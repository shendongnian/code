    [assembly: Dependency(typeof(DbFetcher))]
    namespace App.Droid.Services
    {
        class DbFetcher : IDbDataFetcher
        {
    
            public List<string> GetData(string conn)
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
    
                    SqlCommand command = new SqlCommand("select * from smuser", connection);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            data.Add(reader[0].ToString());
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                    }
                }
                return data;
            }
        }
    }
