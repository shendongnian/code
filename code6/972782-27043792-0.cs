    public class DeepDictionaryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (typeof(IDictionary).IsAssignableFrom(objectType) ||
                    TypeImplementsGenericInterface(objectType, typeof(IDictionary<,>)));
        }
        private static bool TypeImplementsGenericInterface(Type concreteType, Type interfaceType)
        {
            return concreteType.GetInterfaces()
                   .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Type type = value.GetType();
            IEnumerable keys = (IEnumerable)type.GetProperty("Keys").GetValue(value, null);
            IEnumerable values = (IEnumerable)type.GetProperty("Values").GetValue(value, null);
            IEnumerator valueEnumerator = values.GetEnumerator();
            writer.WriteStartArray();
            foreach (object key in keys)
            {
                valueEnumerator.MoveNext();
                writer.WriteStartArray();
                serializer.Serialize(writer, key);
                serializer.Serialize(writer, valueEnumerator.Current);
                writer.WriteEndArray();
            }
            writer.WriteEndArray();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
