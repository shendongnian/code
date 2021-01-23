    public static T RunFunc<T>(Func<SQLiteConnection, T> funcToRun) where T : new()
    {
        using (var db = new SQLiteConnection(DbPath))
        {
            db.Trace = true;
            return funcToRun(db);
       }
    }
