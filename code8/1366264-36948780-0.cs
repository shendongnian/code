    int count;
    using ( var db = new SQLiteConnection( new SQLitePlatformWinRT(), DbPath ) )
    {
        var results = db.Table<TickRecord>().ToList();
        count = ( from p in results
                  where (p.TickStartDate.LocalDateTime >= start && p.TickEndtDate.LocalDateTime <= end )
                  select (int)p.DurationInSeconds ).Sum();
    }
    return count;
