    internal class InMemoryDatabase
    {
        private readonly IDbConnection _connection;
        public InMemoryDatabase()
        {
            _connection = new SQLiteConnection("Data Source=:memory:");
        }
        public IDbConnection OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
            return _connection;
        }
        public void Insert<T>(string tableName, IEnumerable<T> items)
        {
            var con = OpenConnection();
            con.CreateTableIfNotExists<T>(tableName);
            con.InsertAll(tableName, items);
        }
    }
