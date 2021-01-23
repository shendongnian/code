     while (reader.Read())
                        {
                            int commonNo = Convert.ToInt16(reader["incidentNoReserveId"]);
                            //Every new row will create a new dictionary that holds the columns
                            if (Convert.ToInt16(commonNo) == newLastIncidentNo)
                            {
                                reader.Close();
                                //newLastIncidentNo = (Convert.ToInt16(commonNo));
                                using (SqlCommand command = new SqlCommand("Delete from [dbo].[incidentNoReserve] where incidentNoReserveId = @newLastIncidentNo", cnn))
                                {
                                    
                                    //MessageBox.Show(newLastIncidentNo.ToString());
                                    command.Parameters.AddWithValue("@newLastIncidentNo", newLastIncidentNo);
                                    command.ExecuteNonQuery();
                                    
                                }
                            }
                        }
                        
                        cnn.Close();
                    }
                }
                catch (Exception ex)
