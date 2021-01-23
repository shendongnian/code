    public class RedisSharedConnection
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(ConfigurationManager.ConnectionStrings["RedisConnectionString"].ConnectionString);
            connectionMultiplexer.PreserveAsyncOrder = false;
            return connectionMultiplexer;
        });
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
