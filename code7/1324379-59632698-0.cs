    public static BulkWriteResult<T> BulkUpsert<T>(this IMongoCollection<T> collection, IEnumerable<T> records)
        {
            string keyname = "_id";
            
            #region Get Primary Key Name 
            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    BsonIdAttribute authAttr = attr as BsonIdAttribute;
                    if (authAttr != null)
                    {
                        keyname = prop.Name;
                    }
                }
            }
            #endregion
            var bulkOps = new List<WriteModel<T>>();
            foreach (var entry in records)
            {
                var filter = Builders<T>.Filter.Eq(keyname, entry.GetType().GetProperty(keyname).GetValue(entry, null));
                var upsertOne = new ReplaceOneModel<T>(filter, entry){ IsUpsert = true };
                bulkOps.Add(upsertOne);
            }
            return collection.BulkWrite(bulkOps);
        }
        
