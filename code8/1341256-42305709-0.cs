      string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,
                         "ExsistingDatabase.sqlite");
                    conn = new SQLite.Net.SQLiteConnection(new
                       SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
    
