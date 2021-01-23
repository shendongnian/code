                        /************Getting value from database and saving into .srt************/
                        #region Save Srt file 
                        using (SqlConnection Connection = new SqlConnection(database.ConnectionString))
                        {
                            try
                            {
                                Connection.Open();
                                using (SqlCommand Command = new SqlCommand(Query, Connection))
                                {
                                    using (SqlDataAdapter DataAdapter = new SqlDataAdapter(Command))
                                    {
                                        using (DataTable Table = new DataTable())
                                        {
                                            Command.ExecuteNonQuery();
                                            DataAdapter.Fill(Table);
                                            if (Table.Rows.Count > 0)
                                            {
                                                // create a writer and open the file
                                                TextWriter tw = new StreamWriter(TxtSrtName.Text + ".srt");
                                                foreach (DataRow rows in Table.Rows)
                                                {
                                                    
                                                    
                                                    // write a line of text to the file
                                                    tw.WriteLine(rows["Id"].ToString());
                                                    tw.WriteLine(rows["Time"].ToString() + "-->" + rows["Time"].ToString());
                                                    tw.WriteLine(rows["Long"] + " " + rows["Lat"]);
                                                    tw.WriteLine("");
                                                   
                                                    
                                                    // close the stream
                                                    
                                                    
                                                }
                                                tw.Close();
                                            }
                                            else
                                            {
                                                LblLatitude.Text = "No Lattitude";
                                                LblLongitude.Text = "No Longitude";
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally { Connection.Close(); }
                        }
                        #endregion
                        /**********************************************************************/
                        
