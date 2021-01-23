    namespace MongoDB_Test
    {
        class Program
        {
            protected static IMongoClient _client;
            protected static IMongoDatabase _database;
            static Program()
            {
                _client = new MongoClient();
                _database = _client.GetDatabase("test");
            }
        }
    }
