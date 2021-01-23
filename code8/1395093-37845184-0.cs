    MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
    conn_string.Server = serverTextBox.Text;
    conn_string.UserID = userTextBox.Text;
    conn_string.Password = passwordtextBox.Text;
    conn_string.Database = dataBaseTextBox.Text;
    
    using (MySqlConnection conn = new MySqlConnection(conn_string.ToString()))
    using (MySqlCommand cmd = conn.CreateCommand())
    {    
         //query whatever you want, be aware of SQL injection
    }
