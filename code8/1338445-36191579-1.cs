    var pattern = @"(?si)<([^\s<]*workUnit[^\s<]*)>.*?</\1>";
    var filter = Builders<JobInfoRecord>.Filter.Regex(x => x.SerializedBackgroundJobInfo,
                                                  new BsonRegularExpression(pattern, "i"));
    var ops = new List<WriteModel<BsonDocument>>();
    var writeOptions = new BulkWriteOptions() { IsOrdered = false };
    using ( var cursor = await records.FindAsync<BsonDocument>(filter))
    {
        while ( await cursor.MoveNextAsync())
        {
            foreach( var doc in cursor.Current )
            {
                // Replace inspected value
                var updatedJobInfo = Regex.Replace(doc.SerializedBackgroundJobInfo, pattern, "<$1></$1>");
                // Add WriteModel to list
                ops.Add(
                    new UpdateOneModel<BsonDocument>(
                        Builders<BsonDocument>.Filter.Eq("JobTypeValue", doc.JobTypeValue),
                        Builders<BsonDocument>.Update.Set("SerializedBackgroundJobInfo", updatedJobInfo)
                    )
                );
                // Execute once in every 1000 and clear list
                if (ops.Count == 1000)
                {
                    BulkWriteResult<BsonDocument> result = await records.BulkWriteAsync(ops,writeOptions);
                    ops = new List<WriteModel<BsonDocument>>();
                }
            }
        }
        // Clear any remaining
        if (ops.Count > 0 )
        {
            BulkWriteResult<BsonDocument> result = await records.BulkWriteAsync(ops,writeOptions);
        }
    }
