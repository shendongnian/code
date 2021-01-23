    public static WriteConcernResult CreateOrUpdateIndex(
        this MongoCollection mongoCollection,
        IMongoIndexKeys keys,
        IMongoIndexOptions options = null)
    {
        if (mongoCollection.IndexExists(keys))
        {
            var indexDocument = mongoCollection.GenerateIndexDocument(keys, options);
            if (!mongoCollection.GetIndexes().RawDocuments.Any(indexDocument.Equals))
            {
                mongoCollection.DropIndex(keys);
            }
        }
        return mongoCollection.CreateIndex(keys, options);
    }
