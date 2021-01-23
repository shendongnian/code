    //...
    string sql = "SELECT * FROM user WHERE username = @username ;";
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    command.Parameters.AddWithValue("@username", username);
    // Call Prepare after setting the Commandtext and Parameters.
    command.Prepare();
    SQLiteDataReader reader = command.ExecuteReader();
    //...
