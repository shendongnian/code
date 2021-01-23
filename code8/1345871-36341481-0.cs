    MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
    conn_string.Server = "myserver.com";
    conn_string.UserID = "userid";
    conn_string.Password = "password";
    conn_string.Database = "database";
    using (MySqlConnection conn = new MySqlConnection(conn_string.ToString()))
    using (MySqlCommand cmd = conn.CreateCommand())
    {
          cmd.CommandText = "select * from Table1";
          conn.Open();
          cmd.ExecuteNonQuery();
    }
