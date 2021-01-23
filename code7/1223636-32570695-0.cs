    using (SqlConnection con = new SqlConnection(connectionString))
                {
                    CmdString = "SELECT * FROM Conversions WHERE Completed = 'False'";
                    SqlCommand cmd = new SqlCommand(CmdString, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Conversions");
    
    
                    try
                    {
                        sda.Fill(dt);
                    }
                    catch (SqlException sqlexc)
                    {
                        MessageBox.Show("Error:  " + sqlexc.Message);
                        Environment.Exit(0);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Error:  " + exc.Message);
                        Environment.Exit(0);
                    }
    }
