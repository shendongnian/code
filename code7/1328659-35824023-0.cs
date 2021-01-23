    try
            {
                MySqlConnection c = new MySqlConnection("Server=localhost; database=SOIS; UID=root; Pwd=; ");
                 MySqlCommand cmd = new MySqlCommand("Select * from usuarios where empleado_id = '" + username.Text + "'  and password = '" + password.Password + "'", c);
                  MySqlDataReader lectura;
                  c.Open();
                  lectura = cmd.ExecuteReader();
                  int count = 0;
                  bool isAdmin = false;
                  while (lectura.Read()) {
                      count = count + 1;
                      isAdmin = (lecture[3] == 1) ? true : false;
                  }
                  if (count == 1)
                  {
                      MainWindow win2 = new MainWindow();
                      win2.Show();
                      if( isAdmin ) {
                          // if admin open admin form
                      }
                      c.Close();     //In this part I think can add another query and put it into an if
                      this.Close();
                  }
                  else
                  {
                      c.Close();
                    MessageBox.Show("Wrong information");
                }
    
                c.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
