    public class ArrayToObjectConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            if (existingValue == null)
            {
                var contract = serializer.ContractResolver.ResolveContract(objectType);
                existingValue = contract.DefaultCreator();
            }
            switch (reader.TokenType)
            {
                case JsonToken.StartArray:
                    {
                        var jArray = JArray.Load(reader);
                        var jObj = new JObject();
                        foreach (var prop in jArray.OfType<JObject>().SelectMany(o => o.Properties()))
                            jObj.Add(prop);
                        using (var sr = jObj.CreateReader())
                        {
                            serializer.Populate(sr, existingValue);
                        }
                    }
                    break;
                case JsonToken.StartObject:
                    serializer.Populate(reader, existingValue);
                    break;
                default:
                    var msg = "Unexpected token type " + reader.TokenType.ToString();
                    Debug.WriteLine(msg);
                    throw new JsonSerializationException(msg);
            }
            return existingValue;
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
