    public static class SqLiteFacade
    {
        private static SQLiteConnection _sqlLiteConnection;
        private static string _nameOfDatabase = "databaseName.db";
    
        public static async Task<bool> InitializeDatabase()
        {
            try
            {
                _sqlLiteConnection = new SQLiteConnection(new SQLitePlatformWinRT(), await GetPathOfDatabaseInstance(_nameOfDatabase));
    
                _sqlLiteConnection.CreateTable<SqliteDataItem>();
                _sqlLiteConnection.CreateTable<SqliteDataGroup>();
    
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    
        public static SQLiteConnection DbConnection
        {
            get
            {
                return _sqlLiteConnection;;
            }
        }
    
        public static async Task<string> GetPathOfDatabaseInstance(string databaseName)
        {
            if (!await DatabaseExist(databaseName))
            {
                var sampleFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(databaseName, CreationCollisionOption.ReplaceExisting);
            }
    
            var database = await ApplicationData.Current.LocalFolder.GetFileAsync(databaseName);
            return database.Path;
        }
    
        private static async Task<bool> DatabaseExist(string databaseName)
        {
            var files = await ApplicationData.Current.LocalFolder.GetFilesAsync();
    
            return files.Any(file => file.Name == databaseName);
        }
    }
