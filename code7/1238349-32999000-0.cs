     static void Insert()
        {
            try
            {
                string connectionString =System.Configuration.ConfigurationManager.ConnectionStrings["MyETL.Properties.Settings.connectionStr"].ConnectionString;
                using (SqlConnection conn =new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Student(Sid,st_name) VALUES (" +
                           "@id,@name)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", 111);
                        cmd.Parameters.AddWithValue("@Name", "nallia");
                      
        
                        int rows = cmd.ExecuteNonQuery();
        
                        //rows number of record got inserted
                    }
                }
            }
            catch (SqlException ex)
            {
                //Log exception
                //Display Error message
            }
        }
