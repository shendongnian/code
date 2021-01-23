                try
                {
                    SqlCeConnection con = new SqlCeConnection(@"Data Source = D:\C# Projects\StoreFileSqlCe\StoreFileSqlCe\Test_File_Stotage.sdf");
                    con.Open();
                    string strQuery = "select Data where Name = @Name and ContentType = @ContentType";
                    SqlCeCommand cmd = new SqlCeCommand(strQuery, con);
                    cmd.Parameters.AddWithValue("@Name", filename);
                    cmd.Parameters.AddWithValue("@ContentType", "application/vnd.ms-word");
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.Read())
                        {
                            byte[] pdf = (byte[])reader["Data"];
                            File.WriteAllBytes(filename, pdf);
                        }
                    }
                }
    ​
