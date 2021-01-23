    public class MongoAlbum
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Property { get; set; }
    }
    IMongoClient client;
    IMongoDatabase database;
    IMongoCollection<MongoAlbum> collection;
    client = new MongoClient("connection string");
    database = client.GetDatabase("DB name");
    collection = database.GetCollection<MongoAlbum>("collection name");
    IEnumerable<string> albums = await collection.Find(x => x.Id == "1")
                                                     .Project(x => x.Id)
                                                     .ToListAsync();
