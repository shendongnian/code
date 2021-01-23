    public async Task RetrieveEvents()
    {
        var collection = database.GetCollection<BsonDocument>("Events");
        var filter = Builders<BsonDocument>.Filter.Eq("Event", "Idoru");
        var result = await collection.Find(filter).ToListAsync();
        // Do something with result
    }
