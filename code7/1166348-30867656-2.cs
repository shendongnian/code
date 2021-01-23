    public class SqliteAndroid : ISQLite
    	{
    		private SQLiteConnectionWithLock persistentConnection;
    
    		public SQLiteConnectionWithLock GetConnectionWithLock()
    		{
    			if (persistentConnection == null)
    			{
    				var dbFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), Constants.DB_FILE_NAME);
    				var platform = new SQLitePlatformAndroid();
    				var connectionString = new SQLiteConnectionString(dbFilePath, true);
    				persistentConnection = new SQLiteConnectionWithLock(platform, connectionString);
    			}
    				
    			return persistentConnection;
    		}
    	}
