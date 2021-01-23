     public static void fillmyList(ListView myListView, string query)
        {
            myListView.Items.Clear();
            myListView.Columns.Clear();
            string server = "localhost";
            string database = "mydatabaseName";
            string uid = "myUser";
            string password = "MyPassword";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
            try
            {
                //Open connection
                if (OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //Read the data and store them in the listview
                    if (dataReader.FieldCount > 0)
                    {
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            if (i == 0)
                            {
                                myListView.Columns.Add(dataReader.GetName(0), 0, HorizontalAlignment.Left);
							}
                            else
                            {
                                myListView.Columns.Add(dataReader.GetName(i).ToString().Replace("_", " "), 80, HorizontalAlignment.Left);
                            }
                        }
                        ListViewItem lv = new ListViewItem();
                        //
                        while (dataReader.Read())
                        {
                            lv = myListView.Items.Add(dataReader[dataReader.GetName(0)].ToString().Replace('_', ' '));
                            for (int h = 1; h < dataReader.FieldCount; h++)
                            {
                                 
                                    lv.SubItems.Add(dataReader[dataReader.GetName(h)].ToString());
                            }
                        }
                    }
                    for (int i = 1; i < myListView.Columns.Count; i++)
                        myListView.Columns[i].Width = -2;
                    //close Data Reader
                    dataReader.Close();
                    //close Connection
                    CloseConnection();
                             }
            }
            catch (Exception)
            {
                //  MessageBox.Show(ex.Message);
            }
           
        }
		  //open connection to database
        private static bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        //Close connection
        private static bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
