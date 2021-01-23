    static SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), path); // End initialization statement
    static MainCode()
    {
       conn.CreateTable<User>;//Initialize in static constructor
    }
