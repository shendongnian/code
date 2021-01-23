    public async Task AddCustomMetadata()
           {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("EntityCustomMetadataFieldId", "5bf81296-feda-6447-b45a-08d5cb91211c");
                var filter = Builders<BsonDocument>.Filter.Eq("_id", "6c7bb4a5-d7cc-4a8d-aa92-b0c89ea0f7fe");
                var update = Builders<BsonDocument>.Update.Push("CustomMetadata.Fields", dic);
                await _context.BsonAssets.FindOneAndUpdateAsync(filter, update);
            }
