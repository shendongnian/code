    private static DataTable ExecuteTableQuery(String Query)
    {
        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(Query, CONNECTION))
        {
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
