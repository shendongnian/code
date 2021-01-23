    long rowID;
    using (SQLiteConnection con = new SQLiteConnection([datasource])
    {
        SQLiteTransaction transaction = null;
        transaction = con.BeginTransaction();
        [execute insert statement]
        rowID = con.LastInsertRowId;
        transaction.Commit()
    }
