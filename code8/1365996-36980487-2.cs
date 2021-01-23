    public class ReliableSqlConnectionWrapper : DbConnection {
        private readonly ReliableSqlConnection _connection;
        public ReliableSqlConnectionWrapper(ReliableSqlConnection connection) {
            _connection = connection;
        }
        protected override DbTransaction BeginDbTransaction(System.Data.IsolationLevel isolationLevel) {
            return (DbTransaction) _connection.BeginTransaction();
        }
        public override void Close() {
            _connection.Close();
        }
        public override void ChangeDatabase(string databaseName) {
            _connection.ChangeDatabase(databaseName);
        }
        public override void Open() {
            _connection.Open();
        }
        public override string ConnectionString
        {
            get { return _connection.ConnectionString; }
            set { _connection.ConnectionString = value; }
        }
        public override string Database
        {
            get { return _connection.Database; }
        }
        public override ConnectionState State
        {
            get { return _connection.State; }
        }
        public override string DataSource
        {
            get { return _connection.Current?.DataSource; }
        }
        public override string ServerVersion
        {
            get { return _connection.Current?.ServerVersion; }
        }
        protected override DbCommand CreateDbCommand() {
            return _connection.CreateCommand();
        }
    }
