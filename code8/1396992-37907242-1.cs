    static void CreateUser(string username, string password)
    {
        if (UserExists(username))
            throw new InvalidOperationException("User already exists");
    
        string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
        // if you look at the hashed password, notice that it's prepended with the salt generated above
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
    
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            SQLiteCommand insertCommand = new SQLiteCommand(connection);
            insertCommand.CommandText = @"INSERT INTO acc (UserName, Pass) VALUES (@username, @hashedPass);";
            // use parameterised queries to mitigate sql injection
            insertCommand.Parameters.Add(new SQLiteParameter("@username", username));
            insertCommand.Parameters.Add(new SQLiteParameter("@hashedPass", hashedPassword));
            insertCommand.ExecuteNonQuery();
        }
    }
