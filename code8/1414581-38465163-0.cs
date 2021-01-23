    private void OpenConn<TResult>(Func<NpgsqlConnection, TResult> query)
    {
        using (var sqlConn = new NpgsqlConnection("...")
        {
            sqlConn.Open();
            return query(sqlConn);
        }
    }
