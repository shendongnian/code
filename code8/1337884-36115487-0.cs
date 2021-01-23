                            bool first = true;
                            foreach (ListViewItem item in checkedItems)
                            {
                                if (first)
                                    cmdLine = "INSERT INTO " + processToSave + " (Attributes, Value, Picture) VALUES (@Attributes, @Value, @Image);";
                                else
                                    cmdLine = "INSERT INTO " + processToSave + " (Attributes, Value) VALUES (@Attributes, @Value);";
                                using (SqlCommand sqlCmd = new SqlCommand(cmdLine, connection))
                                {
                                    //Parameter definieren
                                    sqlCmd.Parameters.Add("@Attributes", SqlDbType.NVarChar);
                                    sqlCmd.Parameters["@Attributes"].Value = item.Text;
                                    sqlCmd.Parameters.Add("@Value", SqlDbType.Int);
                                    sqlCmd.Parameters["@Value"].Value = Convert.ToInt32(item.SubItems[1].Text);
                                    if (first)
                                    {
                                        sqlCmd.Parameters.Add("@Image", SqlDbType.Image);
                                        sqlCmd.Parameters["@Image"].Value = pic;
                                        first = false;
                                    }
                                    sqlCmd.ExecuteNonQuery();
                                }
                            }
