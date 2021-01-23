    var settings = new JsonSerializerSettings
                    {
                        Converters = new List<JsonConverter> {new SimpleValueObjectConverter()}
                    };</code>
----------
public class SimpleValueObjectConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var valueProperty = GetValueProperty(value.GetType());
            serializer.Serialize(writer, valueProperty.GetValue(value));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var valueProperty = GetValueProperty(objectType);
            var value = serializer.Deserialize(reader, valueProperty.PropertyType);
            return Activator.CreateInstance(objectType, value);
        }
        public override bool CanConvert(Type objectType)
        {
            if (GetDefaultConstructor(objectType) != null) return false;
            var valueProperty = GetValueProperty(objectType);
            if (valueProperty == null) return false;
            var constructor = GetValueConstructor(objectType, valueProperty);
            return constructor != null;
        }
        private static ConstructorInfo GetValueConstructor(Type objectType, PropertyInfo valueProperty)
        {
            return objectType.GetConstructor(new[] {valueProperty.PropertyType});
        }
        private static PropertyInfo GetValueProperty(Type objectType)
        {
            return objectType.GetProperty("Value");
        }
        private static ConstructorInfo GetDefaultConstructor(Type objectType)
        {
            return objectType.GetConstructor(new Type[0]);
        }
    }</code>
