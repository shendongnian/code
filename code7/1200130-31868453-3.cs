    public static async Task WriteCollectionToFile(IMongoDatabase database, string collectionName, string fileName)
    {
        var collection = database.GetCollection<RawBsonDocument>(collectionName);
        // Make sure the file is empty before we start writing to it
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
        using (FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        using (BufferedStream bs = new BufferedStream(fs))
        using (StreamReader sr = new StreamReader(bs))
        {
            var collection = database.GetCollection<BsonDocument>(collectionName);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                await collection.InsertOneAsync(BsonDocument.Parse(line));
            }
        }
    }
