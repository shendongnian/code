        static void Main(string[] args)
        {
            // To directly connect to a single MongoDB server
            // or use a connection string
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<PerUserEntries>("tar");
            var newData = new PerUserEntries();
            newData.Entries = new List<DateTime>();
            for (var i = 0; i < 1000; i++)
            {
                newData.Entries.Add(DateTime.Now.AddSeconds(i));
            }
            collection.InsertOne(newData);
            var list =
                collection.Find(new BsonDocument())
                    .Project<BsonDocument>
                    (Builders<PerUserEntries>.Projection.Slice(x => x.Entries, 0, 3))
                    .ToList();
            Console.ReadLine();
        }
       public class PerUserEntries
        {
            public List<DateTime> Entries;
            public ObjectId TheUser;
            public ObjectId Id { get; set; }
        }
