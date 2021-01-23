    public virtual async Task<UpdateResult> AddEntryToArrayAsync<X>(string address, string id, X el)
        {
            try
            {
                var update = Builders<BsonDocument>.Update.Push(address, el);
                return await Collection.UpdateOneAsync(IdFilter(id), update);
            }
            catch(MongoWriteException e)
            {
                if (e.WriteConcernError == null)
                {
                    var insert = Builders<BsonDocument>.Update.Set(address, new List<X> { el });
                    return await Collection.UpdateOneAsync(IdFilter(id), insert);
                }
                throw e;
            }
        }
