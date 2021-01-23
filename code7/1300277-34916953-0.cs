     DateTime dt = DateTime.Now;
     string str = dt.ToString("yyyy-MM-dd HH:mm:ss.000");
         using (SqlConnection conn = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=**;Persist Security Info=True;User ID=**;Password=**;MultipleActiveResultSets=True;Connection Timeout=600; Application Name=EntityFramework"))
                    {
                        conn.Open();
                        SqlCommand cmd = conn.CreateCommand();
                        try
                        {
                            SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO aa(IndexID,ChangeTime) VALUES (1, Convert(datetime, '{0}', 121)))",str ));
                            cmd.Connection = conn;
                            cmd.ExecuteNonQuery();
                           
                        }
                        catch
                        {
                            throw;
                        }
        
                    }
    )
