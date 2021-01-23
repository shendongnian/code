    public async Task<bool> IsCollectionCapped(string collectionName)
    {
        var command = new BsonDocumentCommand<BsonDocument>(new BsonDocument
        {
            {"collstats", collectionName}
        });
        var stats = await GetDatabase().RunCommandAsync(command);
        return stats["capped"].AsBoolean;
    }
