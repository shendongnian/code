        MySql.Data.MySqlClient.MySqlConnection connection;
            string server = "localhost";
            string database = "weather";
            string uid = "db1";
            string password = "db12121";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        
        try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand("insert into forecast (country,city,temperature) values(@Country,@City,@Temperature)", connection);
                    cmd.Parameters.AddWithValue("@Country", country1);
                    cmd.Parameters.AddWithValue("@City", city1);
                    cmd.Parameters.AddWithValue("@Temperature", temperature);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    DisplayMessage.Text = "Database connection failed.";
                }
        
        
            }
            catch (Exception ex)
            {
                
            }
        
            connection.Close();
    }
