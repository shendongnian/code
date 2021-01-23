    using (SqlConnection conn = new SqlConnection("Data Source=Rogue;Initial Catalog=SoftProject;Integrated Security=True"))
            {           
                conn.Open();
                try
                {
                    String str1 = "";
                    using (SqlCommand cmd = new SqlCommand("Select PlayerName,Score from PlayerData where PlayerName = @player", conn))
                    {
                        cmd.Parameters.AddWithValue("@player", txtPlayer.Text);
                        SqlDataReader reader = cmd.ExecuteReader();
                        
                        if(reader.Read())
                        {
                            str1 = String.Concat(str1, reader.GetString(reader.GetOrdinal("Score")));
                        }
                        else
                        {
                            
                        }
                    }
                    conn.Close();
                }
                catch
                {
                    
                }
                
            }
