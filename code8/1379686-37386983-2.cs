    public static string DB_PATH = Path.Combine(ApplicationData.Current.LocalFolder.Path, "database.sqlite");
    public static SQLite.Net.Platform.WinRT.SQLitePlatformWinRT SQLITE_PLATFORM = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
    
    public App()
    {
        Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
            Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
            Microsoft.ApplicationInsights.WindowsCollectors.Session);
        this.InitializeComponent();
        this.Suspending += OnSuspending;
    
        if (!CheckFileExists("database.sqlite").Result)
        {
            using (var db = new SQLite.Net.SQLiteConnection(SQLITE_PLATFORM, DB_PATH))
            {
                db.CreateTable<DBList>();
            }
        }
    }
    
    private async Task<bool> CheckFileExists(string fileName)
    {
        try
        {
            var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            return true;
        }
        catch
        {
        }
        return false;
    }
