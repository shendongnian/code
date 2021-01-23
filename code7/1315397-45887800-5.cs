        class MongoKeyValuePair<T, TKey>
        {
            [BsonId]
            public TKey Key { get; set; }
            public T Value { get; set; }
            public long Count { get; set; }
        }
            BsonDocument groupDoc = MongoDB.Bson.BsonDocument.Parse(@"
             {
                    _id: '$" + GetPropertyName(KeySelector) + @"',
                    Value: { '$first': '$$CURRENT' },
                    Count: { $sum: 1 }
            }");
