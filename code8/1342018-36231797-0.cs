    using (MySqlConnection connection = new MySqlConnection(DBConnection.ConnectionString))
    {
        connection.Open();
        MySqlCommand getUser = new MySqlCommand("SELECT * FROM `User` WHERE `User`.`UserID` = 42", connection);
        MySqlDataReader reader = getUser.ExecuteReader();
    
        //rest of your code
    }
