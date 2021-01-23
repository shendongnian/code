    var client = new MongoClient();
    var db = client.GetServer().GetDatabase("db");
    var collection = db.GetCollection("collection");
    var query = Query.NE("OriginalMessage", "JUNK");
    var cursor = collection.Find(query).SetSkip(10);
