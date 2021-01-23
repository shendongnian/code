    using (var conn = new SQLiteConnection(@"d:\foo\bar\mySqlite.db"))
    {
        // First turn ON the FK constraint
        using (var statement = conn.Prepare(@"PRAGMA foreign_keys = ON"))
        {
            SQLiteResult result = statement.Step();
        }
        // Then Delete item that will Cascade deletion in referencing table(s)
        using (var statement = conn.Prepare(SqlDeleteItemById()))
        {
            SqlBindIdToDeleteItemById(statement, id);
            SQLiteResult result = statement.Step();
        }
    }
