     try
                {
                    string authority="false";
                    conn.Open();
                    string sql = "select * from tbl_user where username=@uname and password=@pword ";
                    MySqlDataAdapter sda = new MySqlDataAdapter(sql, conn);
                    sda.SelectCommand.Parameters.AddWithValue("@uname", txtuname.Text);
                    sda.SelectCommand.Parameters.AddWithValue("@pword", txtpword.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    string lvl = dt.Rows[0][0].ToString();
                    conn.Close();
                    if (dt.Rows.Count > 0)
                    {
                        authority="true";
                    }
                    if(authority=="true")
                    {
                        MessageBox.Show("Successfully Logged in as " + lvl);
                        authority=false;
                        this.Hide();
                        MainMenu mm = new MainMenu();
                        mm.ShowDialog();                        
                    }
                    else
                    {
                    MessageBox.Show("You are not Authorized user.");
                    }
                    }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                }
