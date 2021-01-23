	public void login() { try {
	if (USERNAME != "" && PASS != "")
            {
				        byte[] utf8Bytes = Encoding.UTF8.GetBytes(PASS);
					String unicodePass = Encoding.Unicode.GetString(utf8Bytes);
			
                string login = "SELECT * from rfidprototype.account where username ='" + USERNAME + "' and UNICODE(password) = '" + unicodePass + "';";
                MySqlCommand cmdDB = new MySqlCommand(login, SQLconn);
                MySqlDataReader DRead;
                DRead = cmdDB.ExecuteReader();
                if (DRead.Read())
                {
                    if (USERNAME == "admin")
                    {
                        MenuHere menu = new MenuHere();
                        menu.Show();
                        SQLconn.Close();
                    }
                    else
                    {
                        MenuHere menu1 = new MenuHere();
                        menu1.Show();
                        menu1.ManageTile.Enabled = false;
                        SQLconn.Close();
                    }
                }
                else
                {
                    //MessageBox.Show("Incorrect Username or Password!");
                    MessageBox.Show("Incorrect Username or Password", "Laptop Ownership Identifier System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DiriLogin form = new DiriLogin();
                    form.ShowDialog();
                }
            }
            else
            {
                // MessageBox.Show("Incorrect Username or Password!");
                MessageBox.Show("Please input username or password", "Laptop Ownership Identifier System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DiriLogin form = new DiriLogin();
                form.ShowDialog();
            }
        }catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
