    public void DisposeConnection()
    {
        SQLiteConnection.Dispose();
        SQLiteCommand.Dispose();   
        GC.Collect();
    }
