    public DataTable ExecuteQuery(string sql)
    {
        SQLiteDataReader rdr = null;
        using(SQLiteConnection conn = new SQLiteConnection(ConnectionString))
        {
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            rdr = cmd.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(rdr);
            return dataTable;
        }
    }
