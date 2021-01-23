    private bool validate_login(string u, string p)
    {
        using(MySqlConnection cnn = DatabaseC.Connection())
        using(MySqlCommand cmd = cnn.CreateCommand())
        {
            cmd.CommandText = "......"
            ...
            using(MySqlDataReader reader = cmd.ExecuteReader())
            {
               .....
            }  // Here the reader is closed and destroyed
        } // Here the connection closed and destroyed with the command 
    }
