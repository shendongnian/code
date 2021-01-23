    public class Engine : IEngine
    {
        private IIndex<ConnectionType, IConnection> _connectionFactory;
        public Engine(IIndex<ConnectionType, IConnection> connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public string Process(ConnectionType connectionType)
        {
            var connection = _connectionFactory[connectionType];
            return connection.Open().ToString();
        }
    }
