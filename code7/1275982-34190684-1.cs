    public async Task<Entity> GetEntityIdByOriginalEmail(string originalEmail)
    {
        var collection = GetCollection();
        var filter = Builders<Entity>.Filter.Regex("x", new BsonRegularExpression(originalEmail, "i"));
        return await collection.Find(filter).FirstOrDefaultAsync();
    }
