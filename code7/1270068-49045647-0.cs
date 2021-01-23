    public  UpdateDefinition<T> getUpdate(T t)
        {
            PropertyInfo[] props = typeof(T).GetProperties();
            UpdateDefinition<T> update = null;
            foreach (PropertyInfo prop in props)
            {
                
                if (t.GetType().GetProperty(prop.Name).PropertyType.Name == "List`1")
                {
                    update = Builders<T>.Update.Set(prop.Name, BsonSerializer.Deserialize<BsonArray>(JsonConvert.SerializeObject(t.GetType().GetProperty(prop.Name).GetValue(t))));
                }
                else if (t.GetType().GetProperty(prop.Name).PropertyType.Name == "object")
                {
                    /* if its object */
                    update = Builders<T>.Update.Set(prop.Name, BsonSerializer.Deserialize<BsonDocument>(JsonConvert.SerializeObject(t.GetType().GetProperty(prop.Name).GetValue(t))));
                }
                else
                {
                    /*if its primitive data type */
                    update = Builders<T>.Update.Set(prop.Name, t.GetType().GetProperty(prop.Name).GetValue(t));
                }
            }
            return update;
        }
