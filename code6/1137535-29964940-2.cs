    public static void RunAction(Action<SQLiteConnection> actionToRun)
    {
        using (var db = new SQLiteConnection(DbPath))
        {
            db.Trace = true;
            actionToRun(db);
       }
    }
