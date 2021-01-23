    public class DataBaseConnection: SQLite.SQLiteConnection
    {
       private const string _path = "MySQlitePath";
       private static SemaphoreSlim _contextMutex = new SemaphoreSlim(1, 5);
       private DataBaseConnection() : base(_path)
       {
       }
    
       public static DataBaseConnection CreateDataBaseConnection()
       {
           _contextMutex.Wait();
           return new DataBaseConnection();
       }
    
       private bool disposed = false;
       protected override void Dispose(bool disposing)
       {
           if (disposed)
              return;
           if(disposing)
           {
              
           }
           disposed = true;
           base.Dispose(disposing);
           _contextMutex.Release();
        }
    }
