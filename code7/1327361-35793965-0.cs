    try
            {
                FileInfo file = new FileInfo("file.xlsx");
                using (var connection1 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DB.mdb"))
                {
                    OleDbCommand cmd = new OleDbCommand();
                    //SqlDataAdapter cmd = new SqlDataAdapter();
                    using (cmd = new OleDbCommand("INSERT INTO simple (doc) values (@file)", connection1))
                    {
                        //cmd.Connection = connection1;
                        connection1.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@file", file);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
 
            }
