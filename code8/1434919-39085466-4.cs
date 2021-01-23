    public static MySqlConnection Connection()
    {
        ConnectionStringSettings conSettings = ConfigurationManager.ConnectionStrings["cs"];
        string conn = conSettings.ConnectionString;
        MySqlConnection connect = new MySqlConnection(conn);
        connect.Open();
        return connect;
    }
