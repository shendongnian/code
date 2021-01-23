    private bool validate_login(string u, string p)
    {
        using(MySqlConnection cnn = DatabaseC.Connection())
        using(MySqlCommand cmd = cnn.CreateCommand())
        {
            cmd.CommandText = "......"
            ...
        }
    }
