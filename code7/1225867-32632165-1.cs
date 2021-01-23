    if (FilterCount > 0) {
                Result = collection.Find(Filter).ToListAsync().GetAwaiter().GetResult();
                return true;
            }
            else {
                Result = collection.Find(new BsonDocument()).ToListAsync().GetAwaiter().GetResult();
                return true;
            }
