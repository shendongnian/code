    var query = @"SELECT id, username, password, salt 
                  FROM users WHERE username=@username";
    using(MySqlConnection cnn = new MySqlConnection(.......))
    using(MySqlCommand cmd = new MySqlCommand(query, cnn))
    {
       cnn.Open();
       cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
       using(MySqlDataReader reader = cmd.ExecuteReader())
       {
           ..... use your data
       }
    }
