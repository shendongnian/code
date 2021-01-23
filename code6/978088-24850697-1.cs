    public static BsonDocument GenerateIndexDocument(this MongoCollection mongoCollection, IMongoIndexKeys keys, IMongoIndexOptions options)
    {
        var optionsDocument = options.ToBsonDocument();
        var keysDocument = keys.ToBsonDocument();
        var indexDocument = new BsonDocument
        {
            { "ns", mongoCollection.FullName },
            { "name", GenerateIndexName(keysDocument, optionsDocument) },
            { "key", keysDocument }
        };
        if (optionsDocument != null)
        {
            indexDocument.Merge(optionsDocument);
        }
        return indexDocument;
    }
    public static string GenerateIndexName(IEnumerable<BsonElement> keys, BsonDocument options)
    {
        const string name = "name";
        if (options != null && options.Contains(name)) return options[name].AsString;
        return string.Join("_", keys.Select(element =>
        {
            var value = "x";
            switch (element.Value.BsonType)
            {
                case BsonType.Int32: value = ((BsonInt32)element.Value).Value.ToString(); break;
                case BsonType.Int64: value = ((BsonInt64)element.Value).Value.ToString(); break;
                case BsonType.Double: value = ((BsonDouble)element.Value).Value.ToString(); break;
                case BsonType.String: value = ((BsonString)element.Value).Value; break;
            }
            return string.Format("{0}_{1}", element.Name, value.Replace(' ', '_'));
        }));
    }
