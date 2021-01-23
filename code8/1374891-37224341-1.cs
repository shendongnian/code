    After search on internet i found solution. 
    
    
    int UserExist = 0;
                    using (SqlCommand cmd1 = new SqlCommand(@"select COUNT(*) from sale where ([date]=@date)  ", con))
                    {   cmd1.Parameters.AddWithValue("date", bildt.Text);
                        UserExist = (int)cmd1.ExecuteScalar();
                       if (UserExist > 0)
                        {using (SqlCommand cmd = new SqlCommand(@"select DISTINCT max(billno) AS bill from sale where ([date]='" + bildt.Text + "')  ", con))
                            { using (SqlDataReader dr = cmd.ExecuteReader())
                                {while (dr.Read())
                                    {
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
                        else {do some thing }
