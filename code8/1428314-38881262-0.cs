            string bsonText = "";
            using(MemoryStream stream = new MemoryStream())
            using(StreamReader reader = new StreamReader(stream))
            using (BsonWriter writer = new Newtonsoft.Json.Bson.BsonWriter(stream))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, message);
                
                stream.Position = 0;
                bsonText = reader.ReadToEnd();
            }
