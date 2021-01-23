    bool CheckLoginDetails(string username, string password){
        string sql = select * from accounts where username = ?";
        MySqlCommand command  = new MySqlCommand(sql);
        command.Parameters.Add(new MySqlParameter("", username));
        MySqlDataReader r = command.ExecuteReader();
        ...
    }
