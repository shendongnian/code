    private const string ConnectionString = "User Id=satan;Password=666;Data Source=MyDB";
    
    public Dal()
    {
    }
    
    public void testCon()
    {
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            OracleCommand cmd = new OracleCommand("insert into myuser values(1,'Pornstar','xxx',18)", connection);
            cmd.Connection.Open();
            MessageBox.Show(connection.ServerVersion);
            cmd.ExecuteNonQuery();
        }
    }
