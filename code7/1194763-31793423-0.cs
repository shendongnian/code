    using (SQLiteTransaction tran = sqLiteconnection.BeginTransaction())
    {
        <for loop inserts here>
        tran.Commit();
    }
    sqLiteconnection.Close();
