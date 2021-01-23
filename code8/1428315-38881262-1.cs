            using(MemoryStream stream = new MemoryStream())
            using (BsonWriter writer = new Newtonsoft.Json.Bson.BsonWriter(stream))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, message);
                
                bsonText = Encoding.UTF8.GetString(stream.ToArray());
            }
