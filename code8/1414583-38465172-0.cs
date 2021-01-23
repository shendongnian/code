    public int OpenConn(Func<NpgsqlConnection, int> func)
    {
        using (var sqlConn = new NpgsqlConnection("...")
        {
            sqlConn.Open();
            return func(sqlConn);
        }
    }
