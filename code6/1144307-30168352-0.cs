    private static void ProcessDocument<T>(T document)where T : class
    {
        Console.WriteLine(document.ToJson());
    }
    static async Task Watch<T>(IMongoCollection<T> collection) where T: class
    { 
        try {
            BsonValue lastId = BsonMinKey.Value;
            while (true) {
                var query = Builders<T>.Filter.Gt("_id", lastId);
                using (var cursor = await collection.FindAsync(query, new FindOptions<T> { 
                    CursorType = CursorType.TailableAwait, 
                    Sort = Builders<T>.Sort.Ascending("$natural") }))
                {
                    while (await cursor.MoveNextAsync())
                    {
                        var batch = cursor.Current;
                        foreach (var document in batch)
                        {
                            lastId = document.ToBsonDocument()["_id"];
                            ProcessDocument(document);
                        }
                    }
                }
            }
        }
        catch (Exception ex) {
            Console.WriteLine("Unhandled exception:");
            Console.WriteLine(ex);
        }
    }
