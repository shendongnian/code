    class DatabaseConnection : IDisposable
    {
        private readonly IDbConnection _conn;
    
        public DatabaseConnection() 
        {
           _conn = new SQLiteConnection(ConnectionString);
        }
    
        public void Dispose()
        {
           _conn.Dispose();
        }
     
        public SQLDataReader ExecuteQuery(string sql) 
        {
            ...
        }
    }
    
    // sample usage
    using (var conn = new DatabaseConnection())
    {
       using (var reader = conn.ExecuteQuery("SELECT ...")
       {
           // do your work in here
       }
    }
