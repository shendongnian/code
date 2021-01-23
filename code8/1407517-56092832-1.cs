    public sealed class Repository
    {
        private readonly Func<Task<NpgsqlConnection>> _connectionFactory;
        public Repository(Func<Task<NpgsqlConnection>> connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<string> GetServerVersionAsync()
        {
            using (var openedConnection = await _connectionFactory())
                return openedConnection.ServerVersion;
        }
    }
