    private SQLiteConnectionWithLock _connection;
    private SQLiteConnectionWithLock Connection
        =>
            _connection ??
            (_connection = new SQLiteConnectionWithLock(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(),
                new SQLiteConnectionString(App.DBPath, false,
                    openFlags:
                        SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex |
                        SQLiteOpenFlags.SharedCache)));
