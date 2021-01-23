    static bool Verify(string username, string password)
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
    
            SQLiteCommand checkUserCommand = new SQLiteCommand(connection)
            {
                CommandText = @"SELECT Pass FROM acc WHERE UserName = @username;"
            };
    
            checkUserCommand.Parameters.Add(new SQLiteParameter("@username", username));
            var hashedPassword = (string)checkUserCommand.ExecuteScalar();                
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);                
        }
    }
