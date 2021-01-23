	static class RedisConnectionManager
	{
		private static readonly Dictionary<string, IDatabase> _dictionary = new Dictionary<string, IDatabase>();
		internal static IDatabase GetDatabase(string connectionString)
		{
			lock (_dictionary)
			{
				if (!_dictionary.ContainsKey(connectionString))
					_dictionary.Add(connectionString, ConnectionMultiplexer.Connect(connectionString).GetDatabase());
				if (!_dictionary[connectionString].Multiplexer.IsConnected)
				{
					_dictionary[connectionString].Multiplexer.Dispose();
					_dictionary[connectionString] = ConnectionMultiplexer.Connect(connectionString).GetDatabase();
				}
				return _dictionary[connectionString];
			}
		}
	}
