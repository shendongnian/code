    public static Dictionary<string, BsonValue> GetFromMongo()
        {
            var collection = _mongodb.GetCollection<BsonDocument>("units");
            var filterBuilder = Builders<BsonDocument>.Filter;
            var filter = filterBuilder.Eq<bool>("isDone", true) & filterBuilder.Exists("isTransformed", false);
            var projection = Builders<BsonDocument>.Projection
                .Include("client")
                .Include("url")
                .Include("fileName")
                .Include("context");
            var document = collection.Find(filter).Project(projection).FirstOrDefault();
            var dictionary = new Dictionary<string, BsonValue>();
            Recurse(document, dictionary);
            return dictionary;
        }
        private static void Recurse(BsonDocument doc, Dictionary<string, BsonValue> dictionary)
        {
            foreach (var elm in doc.Elements)
            {
                if (!elm.Value.IsBsonDocument)
                {
                    if (!dictionary.ContainsKey(elm.Name))
                    {
                        dictionary.Add(elm.Name, elm.Value);
                    }
                }
                else
                {
                    Recurse((elm.Value as BsonDocument), dictionary);
                }
            }
        }
