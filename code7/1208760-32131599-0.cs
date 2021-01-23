    if (decodeStr == null)
                {
                    MessageBox.Show("There is no QR Code!");
                }
                else
                {
                    player.Play();
    
                    MySqlConnection connection;
                    string cs = @"server=server ip;userid=username;password=userpass;database=databse";
                    connection = new MySqlConnection(cs);
                    connection.Open();
    
                    MySqlCommand command = new MySqlCommand();
                    string SQL = "Select Name, LPN From visitors Where password = @password";
                    command.CommandText = SQL;
                    command.Parameters.Add("@password", decodeStr);
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                    connection.Close();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        MessageBox.Show("he");
    
                        name = reader["Name"].ToString();
                        lpn = reader["LPN"].ToString();
                    }
    
                    CheckForIllegalCrossThreadCalls = false;
                    //reader.Close();
                    videoStream.Stop();
                    this.Hide(); // closes the Form2 instance.
                    Application.Run(new VisitorData());
    
                }
