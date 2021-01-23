        /// <summary>
        /// Mongo-ified version of <see cref="KeyValuePair{TKey, TValue}"/>
        /// </summary>
        class InternalKeyValuePair<T, TKey>
        {
            [BsonId]
            public TKey Key { get; set; } 
            public T Value { get; set; }
        }
        //you may not need this method to be completely generic, 
        //but have the sortkey be the same helps
        interface IDateModified
        {
            DateTime DateAdded { get; set; }
        }
        private List<T> GroupFromMongo<T,TKey>(string KeyName) where T : IDateModified
        {
            //mongo linq driver doesn't support this syntax, so we make our own bsondocument. With blackjack. And Hookers. 
            BsonDocument groupDoc = MongoDB.Bson.BsonDocument.Parse(@"
             {
                    _id: '$" + KeyName + @"',
                    Value: { '$first': '$$CURRENT' }
            }");
            //you could use the same bsondocument parsing trick to get a generic 
            //sorting key as well as a generic grouping key, or you could use
            //expressions and lambdas and make it...perfect.
            SortDefinition<T> sort = Builders<T>.Sort.Descending(document => document.DateAdded);
            List<BsonDocument> intermediateResult = getCol<T>().Aggregate().Sort(sort).Group(groupDoc).ToList();
            InternalResult<T, TKey>[] list = intermediateResult.Select(r => MongoDB.Bson.Serialization.BsonSerializer.Deserialize<InternalResult<T, TKey>>(r)).ToArray();
            return list.Select(z => z.Value).ToList();
        }
