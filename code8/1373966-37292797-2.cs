        // get the buses by bus number
        public static List<Buses> GetStopListByBusNumber(string busNumber)
        {
            List<Buses> results = new List<Buses>();
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DBPath))
            {
                results = conn.Query<Buses>("SELECT * FROM Buses WHERE number = ?", busNumber);
            }
            return results;
        }
