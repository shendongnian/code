    public void Insert(String username, String password)
    {
        //Hash and salt password here (this is pseudo code)
        String HASHED_AND_SALTED_PASSWORD = StrongHash(password + GenerateSalt());
        //open connection
        if (this.OpenConnection()) 
        {
            string query = "INSERT INTO logins (`name`, password) VALUES (@UserName, @Password)";
            //Create command and assign query
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Add parameters
            cmd.Parameters.AddWithValue ("@UserName", name);
            cmd.Parameters.AddWithValue ("@Password", HASHED_AND_SALTED_PASSWORD);
            //Execute command
            cmd.ExecuteNonQuery();
            //close connection
            this.CloseConnection();
        }
    }
