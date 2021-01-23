    class data
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int idData { get; set; }
        public string info { get; set; }
    }
    public class sqliteDB
    {
        private string dbPath;
        public SQLiteConnection db;
        public sqliteDB()
        {
            this.dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
        }
        public string getPath() {
            return this.dbPath;
        }
        public void close()
        {
            db.Close();
        }
        public void createDB()
        {
            if (!FileExists("db.sqlite").Result)
            {
                open();
                using (this.db)
                {
                    this.db.CreateTable<data>();
                }
            }
        }
        public void open()
        {
            this.db = new SQLiteConnection(dbPath);
        }
        private async Task<bool> FileExists(string fileName)
        {
            var result = false;
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                result = true;
            }
            catch { }
            return result;
        }
    }
