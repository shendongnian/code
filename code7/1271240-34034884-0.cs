    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    namespace Example
    {
        class FooItem
        {
            public DateTime DateTime { get; set; }
            public string Value { get; set; }
        }
    
        class InsertTest
        {
            protected static IMongoClient _client;
            protected static IMongoDatabase _db;
    
            static void Main(string[] args)
            {
                _client = new MongoClient();
                _db = _client.GetDatabase("Database");
                MainAsync(args).GetAwaiter().GetResult();
            }
    
            static IEnumerable<FooItem> GetList()
            {
                yield return new FooItem
                {
                    DateTime = DateTime.Now,
                    Value = "I am foo 1"
                };
                yield return new FooItem
                {
                    DateTime = DateTime.Now,
                    Value = "I am foo 2"
                };
            }
    
            static async Task MainAsync(string[] args)
            {
                var collection = _db.GetCollection<BsonDocument>("data");
                foreach (var item in GetList())
                {
                    await collection.InsertOneAsync(item.ToBsonDocument());
                }
            }
        }
    }
