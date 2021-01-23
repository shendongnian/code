    // The database path.   
    public static string DB_PATH =Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "sample.sqlite"));   
    // The sqlite connection.   
    private SQLiteConnection dbConn = new SQLiteConnection(DB_PATH);
    dbConn.CreateTable<Task>();
