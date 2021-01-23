        /// <summary>
        /// Mongo-ified version of <see cref="KeyValuePair{TKey, TValue}"/>
        /// </summary>
        class MongoKeyValuePair<T, TKey>
        {
            [BsonId]
            public TKey Key { get; set; }
            public T Value { get; set; }
        }
        private MongoKeyValuePair<T, TKey>[] GroupFromMongo<T, TKey>(Expression<Func<T, TKey>> KeySelector, Expression<Func<T, object>> SortSelector)
        {
            //mongo linq driver doesn't support this syntax, so we make our own bsondocument. With blackjack. And Hookers. 
            BsonDocument groupDoc = MongoDB.Bson.BsonDocument.Parse(@"
             {
                    _id: '$" + GetPropertyName(KeySelector) + @"',
                    Value: { '$first': '$$CURRENT' }
            }");
            SortDefinition<T> sort = Builders<T>.Sort.Descending(SortSelector);
            List<BsonDocument> groupedResult = getCol<T>().Aggregate().Sort(sort).Group(groupDoc).ToList();
            MongoKeyValuePair<T, TKey>[] deserializedGroupedResult = groupedResult.Select(r => MongoDB.Bson.Serialization.BsonSerializer.Deserialize<MongoKeyValuePair<T, TKey>>(r)).ToArray();
            return deserializedGroupedResult;
        }
 
        /* This was my original non-generic method with hardcoded strings, PhonesDocument is an abstract class with many implementations */
        public List<T> ListPhoneDocNames<T>() where T : PhonesDocument
        {
            return GroupFromMongo<T,String>(z=>z.FileName,z=>z.DateAdded).Select(z=>z.Value).ToList();
        }
        public string GetPropertyName<TSource, TProperty>(Expression<Func<TSource, TProperty>> propertyLambda)
        {
            Type type = typeof(TSource);
            MemberExpression member = propertyLambda.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    propertyLambda.ToString()));
            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    propertyLambda.ToString()));
            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(string.Format(
                    "Expresion '{0}' refers to a property that is not from type {1}.",
                    propertyLambda.ToString(),
                    type));
            return propInfo.Name;
        }
