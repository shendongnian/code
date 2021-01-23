     ...
     if (r.Cells[0].Value != null)
                    {
                        cmd.Parameters.Add("@item",r.Cells[0].Value.ToString());
                        
                        try
                        {
                            conDataBase.Open();
                            int res= cmd.ExecuteNonQuery();
                            conDataBase.Close(); //You have to close the connection
                            //displays a system error message if a problem is found
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
