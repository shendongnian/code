    public sealed class BsonDocumentWithNulls : BsonDocument
        {
            public BsonDocument doc { get; set; }
    
            public BsonDocumentWithNulls()
            {
                doc = new BsonDocument();
            }
    
            public BsonDocumentWithNulls(string key, BsonValue value)
            {
                doc = new BsonDocument();
                if (value == null)
                    doc.Add(key, BsonNull.Value);
                else
                    doc.Add(key, value);
            }
    
            public BsonDocumentWithNulls(IDictionary<string, object> dictionary)
            {
                doc = new BsonDocument();
                foreach (var keyValue in dictionary)
                {
                    if (keyValue.Value == null)
                        doc.Add(keyValue.Key, BsonNull.Value);
                    else
                        doc.Add(keyValue.Key, BsonValue.Create(keyValue.Value));
                }
            }
    
            public override string ToString()
            {
                return doc.ToString();
            }
    
            public BsonDocument ToBsonDocument()
            {
                return doc;
            }
        }
