        public class EmbeddedLiteralConverter<T> : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof(T).IsAssignableFrom(objectType);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null)
                    return null;
                var contract = serializer.ContractResolver.ResolveContract(objectType);
                if (contract is JsonPrimitiveContract)
                    throw new JsonSerializationException("Invalid type: " + objectType);
                if (existingValue == null)
                    existingValue = contract.DefaultCreator();
                if (reader.TokenType == JsonToken.String)
                {
                    var json = (string)JToken.Load(reader);
                    var token = JToken.Parse(json);
                    using (var subReader = token.CreateReader())
                        serializer.Populate(subReader, existingValue);
                }
                else
                {
                    serializer.Populate(reader, existingValue);
                }
                return existingValue;
            }
            public override bool CanWrite { get { return false; } }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
    Then use it like:
            var root = JsonConvert.DeserializeObject<RootObject>(json, new EmbeddedLiteralConverter<Body>());
