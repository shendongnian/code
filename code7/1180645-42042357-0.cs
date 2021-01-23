    public async Task UpdateStatus(string accountName, int itemId, int newStatusCode)
    {
        var filter = Builders<Account>.Filter.And(
            Builders<Account>.Filter.Where(x => x.Name == accountName),
            Builders<Account>.Filter.ElemMatch(x => x.OwnedItems, x => x.ItemId == itemId));
        // -1 means update first matching array element
        var update = Builders<Account>.Update
                     .Set(x => x.OwnedItems[-1].StatusCode, newStatusCode);
        Console.WriteLine(update.Render(collection.DocumentSerializer, collection.Settings.SerializerRegistry).ToString());
        // { "$set" : { "OwnedItems.$.StatusCode" : 123 } }
        await collection.UpdateOneAsync(filter, update);
    }
