                                    String x = dr["bill"].ToString();
                                    txttemp.Text = x;
                                    int a;
                                    int.TryParse(txttemp.Text, out a);
                                    billno.Text = (a + 1).ToString();
                                    txttemp.Text = "";
                                }
                                dr.Close(); dr.Dispose();
                            }
                        }
                        }
                    else
