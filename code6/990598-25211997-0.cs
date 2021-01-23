    using (OleDbConnection conn = new OleDbConnection("connection string"))
    {
        using (OleDbCommand cmd = conn.CreateCommand())
        {
            // do stuff
            cmd.ExecuteNotQuery();
        }
    }
