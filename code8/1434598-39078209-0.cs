    public bool IsConnect()
        {
            bool result = true;
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    result = false;
                string connstring = string.Format("Server=192.168.0.254; database={0}; UID=show; password=", "");
    
                try
                {
    			//Database name is not empty 
    			if(result)
                    {
    				connection = new MySqlConnection(connstring);
                    connection.Open();
                    result = true;
    				}
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 0:
                            // MessageBox.Show("Cannot connect to server.  Contact administrator");
                            break;
                        case 1045:
                            // MessageBox.Show("Invalid username/password, please try again");
                            break;
                    }
                }
    
            }
    
            return result;
        }
