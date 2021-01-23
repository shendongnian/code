    if (RedisConn == null)
            { 
                ConfigurationOptions option = new ConfigurationOptions
                {
                    AbortOnConnectFail = false,
                    EndPoints = { redisEndpoint }
                };
                RedisConn = ConnectionMultiplexer.Connect(option);
            }
