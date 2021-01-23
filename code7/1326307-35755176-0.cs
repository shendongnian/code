    using (DatabaseManager db = factory.NewDatabaseManager())
    {
        //code
    } 
    
    public class DatabaseManager : IDisposable
    {
        private SqlConnection _connection;
    
        public DatabaseManager(SqlConnection connection)
        {
             _connection = connection;
        }
        public void Dispose() {
            _connection.Dispose();
        }
    }
