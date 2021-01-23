     try
                    {
                        conn.Open();
    
                        string sql = "select * from tbl_user where username=@uname and password=@pword ";
    
                        MySqlDataAdapter sda = new MySqlDataAdapter(sql, conn);
                        sda.SelectCommand.Parameters.AddWithValue("@uname", txtuname.Text);
                        sda.SelectCommand.Parameters.AddWithValue("@pword", txtpword.Text);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        string lvl = dt.Rows[0][0].ToString();
                         int role=convert.ToInt32(dt.Rows[rowindex][coloumnindex].ToString());
                        conn.Close();
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Successfully Logged in as " + lvl);
                            this.Hide();   
   
                    if(role == 1)
                         {
                     //show the page for the corresponding user role.
                         }
                      else if(role == 2)
                          {
                           //show the page for the corresponding user role.
                             }
                     else if(role == 3)
                        {
                        //show the page for the corresponding user role.
                           }   
                        }
    
                    }
    
                    catch (Exception a)
                    {
                        MessageBox.Show(a.Message);
                    }
                }
            }
