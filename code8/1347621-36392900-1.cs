    var filter = new BsonDocument();
    var options = new FindOptions<BsonDocument>
    {
        // Get 100 docs at a time
        BatchSize = 100
    };
    using (var cursor = await test.FindAsync(filter, options))
    {
        // Move to the next batch of docs
        while (await cursor.MoveNextAsync())
        {
            var batch = cursor.Current;
            foreach (var doc in batch)
            {
                // process doc
            }
        }
    }
