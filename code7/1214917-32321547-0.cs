    public SQLiteDataReader ExecuteQuery(string sql)
    {
        SQLiteDataReader rdr = null;
        using(SQLiteConnection conn = new SQLiteConnection(ConnectionString))
        {
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            rdr = cmd.ExecuteReader();
        }
        // *** Connection gone at this stage ***
        return rdr;
    }
