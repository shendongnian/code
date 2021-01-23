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
                    using (var subReader = new JsonTextReader(new StringReader(json)))
                    {
                        // By populating a pre-allocated instance we avoid an infinite recursion in EmbeddedLiteralConverter<T>.ReadJson()
                        // Re-use the existing serializer to preserve settings.
                        serializer.Populate(subReader, existingValue);
                    }
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
    Note that the converter checks to see whether the incoming JSON token is a string, and if not, deserializes directly.  Thus the converter should be usable when the `"body"` JSON is and is not double-serialized.
