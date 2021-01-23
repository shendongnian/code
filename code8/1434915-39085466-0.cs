    public static MySqlConnection Connection()
    {
        try
        {
            ConnectionStringSettings conSettings = ConfigurationManager.ConnectionStrings["cs"];
            string conn = conSettings.ConnectionString;
            MySqlConnection connect = new MySqlConnection(conn);
            connect.Open();
            return connect;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
