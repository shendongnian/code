    public string dbPath()
    {
        try
        {
             dbConn = 
                 new SQLiteConnection(@"Data Source=C:\Users\ommited\file\path\ChinookSqlite.sqlite;
                     FailIfMissing=True");
             if (!isConnected())
             {
                  dbConn.Open();
             }
        }
        catch (Exception ex)
        {
             //the database file does not exists..
        }
    }
