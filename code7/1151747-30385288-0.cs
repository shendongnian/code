    public async Task<ReplaceOneResult> Save(Hamster hamster)
    {
        var replaceOneResult = await collection.ReplaceOneAsync(
            doc => doc.Id == hamster.Id, 
            hamster, 
            new UpdateOptions {IsUpsert = true});
        return replaceOneResult;
    }
