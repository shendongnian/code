    public class SingleOrResultListConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ICollection<T>).IsAssignableFrom(objectType);
        }
        const string Results = "results";
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            if (objectType.IsArray)
            {
                var list = (List<T>)ReadJson(reader, typeof(List<T>), new List<T>(), serializer);
                return list.ToArray();
            }
            else
            {
                var list = (ICollection<T>)(existingValue ?? serializer.ContractResolver.ResolveContract(objectType).DefaultCreator());
                if (reader.TokenType == JsonToken.StartArray)
                {
                    serializer.Populate(reader, list);
                }
                else if (reader.TokenType == JsonToken.StartObject)
                {
                    JObject obj = null;
                    while (reader.Read())
                    {
                        switch (reader.TokenType)
                        {
                            case JsonToken.PropertyName:
                                string propertyName = reader.Value.ToString();
                                if (!reader.Read())
                                {
                                    throw new JsonSerializationException("Unexpected end while reading collection");
                                }
                                if (propertyName == Results)
                                {
                                    serializer.Populate(reader, list);
                                }
                                else
                                {
                                    obj = obj ?? new JObject();
                                    obj[propertyName] = JToken.Load(reader);
                                }
                                break;
                            case JsonToken.Comment:
                                break;
                            case JsonToken.EndObject:
                                if (obj != null)
                                    list.Add(obj.ToObject<T>(serializer));
                                return list;
                        }
                    }
                    throw new JsonSerializationException("Unexpected end while reading collection");
                }
                else
                {
                    throw new JsonSerializationException("Unexpected start token: " + reader.TokenType);
                }
                return list;
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var collection = (ICollection<T>)value;
            if (collection.Count == 1)
            {
                serializer.Serialize(writer, collection.First());
            }
            else
            {
                writer.WriteStartObject();
                writer.WritePropertyName(Results);
                writer.WriteStartArray();
                foreach (var item in collection)
                {
                    serializer.Serialize(writer, item);
                }
                writer.WriteEndArray();
                writer.WriteEndObject();
            }
        }
    }
