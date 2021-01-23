    var connectionString = ConfigurationManager.AppSettings["connectionString"];
    var client = new MongoClient(connectionString);
    var database = client.GetDatabase("ES");  
    var collection = database.GetCollection<BsonDocument>("MyCollection");
    var persons = await collection.Find(new BsonDocument()).ToListAsync();
