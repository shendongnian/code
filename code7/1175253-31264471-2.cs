    public class Repository
    {
        private readonly string _connectionString;
        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected T GetConnection<T>(Func<IDbConnection, T> getData)
        {
            var connectionString = _connectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return getData(connection);
            }
        }
    }
