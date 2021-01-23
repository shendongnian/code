    using (var cmd = new SQLiteCommand(conn))
    using (var transaction = conn.BeginTransaction())
    {
        for (int y = 0; y < castarraylist.Count; y++)
        {
            //Add your query here.
            cmd.CommandText = "INSERT INTO TABLE (Field1,Field2) VALUES ('A', 'B');";
            cmd.ExecuteNonQuery();
        }
        transaction.Commit();
    }
