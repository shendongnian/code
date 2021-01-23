    private async void DoSomething(ObjectId id, string ip)
    {
        MongoClient client = new MongoClient(connectionString);
        var db = client.GetDatabase("databaseName");
        var collection = db.GetCollection<YourClass>("collectionName");
        var update = Builders<YourClass>.Update.Set(x => x.Agent, ip);
        var result = await collection.UpdateOneAsync(x => x.Id == id, update);
        // you can check update result here
    }
