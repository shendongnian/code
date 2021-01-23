    public static ConnectionMultiplexer RedisConnection;
    public static IDatabase RedisCacheDb;
    protected void Session_Start(object sender, EventArgs e)
        {
            if (ConfigurationManager.ConnectionStrings["RedisCache"] != null)
            {
                if (RedisConnection == null || !RedisConnection.IsConnected)
                {
                    RedisConnection = ConnectionMultiplexer.Connect(ConfigurationManager.ConnectionStrings["RedisCache"].ConnectionString);
                }
                RedisCacheDb = RedisConnection.GetDatabase();
            }
        }
