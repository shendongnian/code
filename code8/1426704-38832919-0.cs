               private void btnLogin_Click(object sender, EventArgs e)
                        {
                            string currentUserID=string.Empty;
                            SqlConnection connection= new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand();
                            command.CommandText = "SELECT UserID From UserPass WHERE username =@username AND password =@password";
                            command.Parameters.AddWithValue("@username", txtUsername.Text);
                            command.Parameters.AddWithValue("@password", txtPassword.Text);
                            command.Connection = connection;
                            object obj=command.ExecuteScalar();
                            if (obj!=null)
                            {
                                currentUserID= obj.ToString();
                                connection.Close();
                                Mainform frm = new Mainform();
                                frm.Show();
                                this.Hide();         
                            }
                            else
                            {
                            connection.Close();
                            MessageBox.Show("Invalid credentials!\nPlease enter a valid username and password to continue.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
       
                        }
