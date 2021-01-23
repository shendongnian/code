     public static string ServerConnectionString()
        {
            var connectionStringBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = ConfigurationManager.AppSettings["Server"],
                Username = ConfigurationManager.AppSettings["UserId"],
                Database = "postgres",
                Password = ConfigurationManager.AppSettings["Password"],
                CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["CommandTimeout"]),
                ApplicationName = EverestEnums.ConnectionApplicationName.EverestServerChecker.ToString(),
                //  MaxPoolSize = 200,
                //   SyncNotification = true,
                KeepAlive = 1,
                ConnectionIdleLifetime = 1,
              //  MinPoolSize = 1,
                Pooling = false
            };
            return connectionStringBuilder.ConnectionString;
        }
