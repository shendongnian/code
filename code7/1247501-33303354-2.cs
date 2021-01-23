	public class Engine : IEngine
	{
		private Func<ConnectionType, IConnection> _connectionFactory;
		public Engine(Func<ConnectionType, IConnection> connectionFactory)
		{
			_connectionFactory = connectionFactory;
		}
		public string Process(ConnectionType connectionType)
		{
			var connection = _connectionFactory(connectionType);
			return connection.Open().ToString();
		}
	}
