    public async Task UpdateStatus(string accountName, int itemId, int newStatusCode)
    {
        var filter = Builders<Account>.Filter.And(
            Builders<Account>.Filter.Where(x => x.Name == accountName),
            Builders<Account>.Filter.ElemMatch(x => x.OwnedItems, x => x.ItemId == itemId));
        var update = Builders<Account>.Update.Set("OwnedItems.$.StatusCode", newStatusCode);
        await collection.UpdateOneAsync(filter, update);
    }
