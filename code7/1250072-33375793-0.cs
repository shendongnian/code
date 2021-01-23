    public DataTable getSiteForRotator()
    {
        DataTable result = new DataTable();
        string CommandText = "SELECT `url`, `desc`, `timer` FROM sites";
        string Connect = "connection_string";
        using(MySqlConnection myConnection = new MySqlConnection(Connect))
        using(MySqlDataAdapter da = new MySqlDataAdapter(CommandText))
            da.Fill(dt);
        return dt;
    }
