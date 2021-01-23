    public class MyService
    {
        private readonly Func<DbConnection> _connectionGetter;
        private DbConnection _connection = null;
        public DbConnection Connection
        {
            get { return _connection ?? (_connection = _connectionGetter()); }
        }
        public MyService(Func<DbConnection> connectionGetter)
        {
            _connectionGetter = connectionGetter;
        }
    }
