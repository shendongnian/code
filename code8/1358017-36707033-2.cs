    string query = "UPDATE user SET username = @username  WHERE user_id = @user_id";
    MySqlCommand com = new MySqlCommand(query, connection);
    com.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
    com.Parameters.Add("@user_id", MySqlDbType.VarChar).Value = user_id;
    // execute query here
