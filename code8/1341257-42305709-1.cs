    using (conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path))
                {
                    var result = conn.Query<ObjectModel>(@"Select * From TableName");
                }
  
