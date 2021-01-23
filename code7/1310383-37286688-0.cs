    public class Database
    {
        string path;
        SQLite.Net.SQLiteConnection conn;
        public Database()
        {
            path = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "Data", "Questions.sqlite");
            conn = new SQLite.Net.SQLiteConnection(new
               SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
        }
    }
