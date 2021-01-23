            int count;
            using ( var db = new SQLiteConnection( new SQLitePlatformWinRT(), DbPath ) )
                {
                count = ( from p in db.Table<TickRecord>()
                          where ( p.TickStartDate >= start && p.TickEndDate <= end )
                          select (int)p.DurationInSeconds ).Sum();
                }
            return count;
