        MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
    conn_string.Server = "yourserver.com";
    conn_string.UserID = "youruser";
    conn_string.Password = "yourpass";
    conn_string.Database = "yourdatabasename";
    
    using (MySqlConnection conn = new MySqlConnection(conn_string.ToString()))
    using (MySqlCommand cmd = conn.CreateCommand())
    {    //watch out for this SQL injection vulnerability below
         cmd.CommandText = string.Format("SELECT * FROM Users --Just to test");
         connection.Open();
         cmd.ExecuteNonQuery();
    }
