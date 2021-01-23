    using (var conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();//connect to mysql
    
                        string sql = "SELECT user, pass FROM users WHERE user=@username and pass=@password";
                        using (var cmd = new MySqlCommand(sql, conn))
                        {
    
                            string username1 = textUser.Text;
                            string password1 = txt_passwordBox.Password;
    
                            cmd.Parameters.AddWithValue("@username", username1);
                            cmd.Parameters.AddWithValue("@password", password1);
    
                            using (var rdr = cmd.ExecuteReader())
                            {
                                if (!rdr.HasRows)
                                {
                                    MessageBox.Show("Wrong Username or Password");
                                    return;
                                }
                                while (rdr.Read())
                                {
    
                                    if (Convert.ToString(rdr["password"]) != password1)
                                    {
                                        MessageBox.Show("Wrong password");
                                    }
                                    else if (Convert.ToString(rdr["username"]) != username1)
                                    {
    
                                        MessageBox.Show("Wrong Username");
                                    }
                                    else if ((Convert.ToString(rdr["username"]) != username1) && (Convert.ToString(rdr["password"]) != password1))
                                    {
    
                                        MessageBox.Show("Wrong Username or Password");
                                    }
                                    else
                                    {
                                        //textError.Text = (rdr["username"] + " --- " + rdr["password"]);
                                        loggedinwindowpumpkin window = new loggedinwindowpumpkin();
                                        this.Close();
                                        window.ShowDialog();
                                        // }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error Connecting.... Check Network Settings, Close and try again");
                        // MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        //MessageBox.Show("Wrong User or Password");
                    }
                }
