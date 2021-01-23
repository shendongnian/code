    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class JsonAnyPropertyNameAttribute : System.Attribute
    {
    }
    class JsonAnyPropertyNameConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException("This converter is intended to be applied directly to a type or a property.");
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            try
            {
                int defaultCount = 0;
                var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(objectType);
                if (existingValue == null)
                    existingValue = contract.DefaultCreator();
                while (reader.Read())
                {
                    switch (reader.TokenType)
                    {
                        case JsonToken.Comment:
                            break;
                        case JsonToken.PropertyName:
                            {
                                var name = reader.Value.ToString();
                                var property = contract.Properties.GetClosestMatchProperty(name);
                                if (!reader.Read())
                                    throw new JsonSerializationException(string.Format("Missing value at path: {0}", reader.Path));
                                if (property == null)
                                {
                                    property = contract.Properties.Where(p => p.AttributeProvider.GetAttributes(true).OfType<JsonAnyPropertyNameAttribute>().Any()).Single();
                                    defaultCount++;
                                    if (defaultCount > 1)
                                    {
                                        throw new JsonSerializationException(string.Format("Too many properties with unknown names for type {0} at path {1}", objectType, reader.Path));
                                    }
                                }
                                var value = serializer.Deserialize(reader, property.PropertyType);
                                property.ValueProvider.SetValue(existingValue, value);
                            }
                            break;
                        case JsonToken.EndObject:
                            return existingValue;
                        default:
                            throw new JsonSerializationException(string.Format("Unknown token {0} at path: {1} ", reader.TokenType, reader.Path));
                    }
                }
                throw new JsonSerializationException(string.Format("Unclosed object at path: {0}", reader.Path));
            }
            catch (Exception ex)
            {
                if (ex is JsonException)
                    throw;
                // Wrap any exceptions encountered in a JsonSerializationException
                throw new JsonSerializationException(string.Format("Error deserializing type {0} at path {1}", objectType, reader.Path), ex);
            }
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
