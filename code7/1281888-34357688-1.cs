    public static void CheckAuthentication(MongoCredential credential, MongoServerAddress server)
        {
            try
            {
                var clientSettings = new MongoClientSettings()
                {
                    Credentials = new[] {credential},
                    WaitQueueTimeout = new TimeSpan(0, 0, 0, 1),
                    ConnectTimeout = new TimeSpan(0, 0, 0, 1),
                    Server = server,
                    ClusterConfigurator = builder =>
                    {
                        //The "Normal" Timeout settings are for something different. This one here really is relevant when it is about
                        //how long it takes until we stop, when we cannot connect to the MongoDB Instance
                        //https://jira.mongodb.org/browse/CSHARP-1018, https://jira.mongodb.org/browse/CSHARP-1231
                        builder.ConfigureCluster(
                            settings => settings.With(serverSelectionTimeout: TimeSpan.FromSeconds(1)));
                    }
                };
                var mongoClient = new MongoClient(clientSettings);
                var testDB = mongoClient.GetDatabase("test");
                var cmd = new BsonDocument("count", "foo");
                var result = testDB.RunCommand<BsonDocument>(cmd);
            }
            catch (TimeoutException e)
            {
                if (e.Message.Contains("auth failed"))
                {
                    Console.WriteLine("Authentication failed");
                }
                throw;
            }
        }
