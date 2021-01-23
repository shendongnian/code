    private bool validate_login(string user, string pass)
    {
        using(MySqlConnection cnn = db_connection())
        using(MySqlCommand cmd = new cnn.CreateCommand())
        {
             cmd.CommandText = ".....";
             cmd.Parameters.AddWithValue("@user", user);
             cmd.Parameters.AddWithValue("@pass", pass);
             using(MySqlDataReader login = cmd.ExecuteReader())
                return login.HasRows;
        }
    }
