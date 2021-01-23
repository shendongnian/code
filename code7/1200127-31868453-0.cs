    public static async Task WriteCollectionToFile(IMongoDatabase database, string collectionName, string fileName)
    {
        var collection = database.GetCollection<RawBsonDocument>(collectionName);
        File.WriteAllText(fileName, string.Empty);
        using (var cursor = await collection.FindAsync(new BsonDocument()))
        {
            while (await cursor.MoveNextAsync())
            {
                var batch = cursor.Current;
                foreach (var document in batch)
                {
                    File.AppendAllLines(fileName, new[] { document.ToString() });
                }
            }
        }
    }
    public static async Task LoadCollectionFromFile(IMongoDatabase database, string collectionName, string fileName)
    {
        var documents = File.ReadAllLines(fileName);
        var collection = database.GetCollection<BsonDocument>(collectionName);
        foreach (var document in documents)
        {
            await collection.InsertOneAsync(BsonDocument.Parse(document));
        }
    }
