    public class HashSetArrayConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            IEnumerable collectionObj = (IEnumerable)value;
            writer.WriteStartObject();
            foreach (object currObj in collectionObj)
            {
                serializer.Serialize(writer, currObj);
            }
            writer.WriteEndObject();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, objectType);
        }
        public override bool CanConvert(Type objectType)
        {
            var canConvert = IsAssignableToGenericType(objectType, typeof(HashSet<>));
            return canConvert;
        }
        private static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            var interfaceTypes = givenType.GetInterfaces();
            if (interfaceTypes.Any(it => it.IsGenericType && it.GetGenericTypeDefinition() == genericType))
            {
                return true;
            }
            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
                return true;
            Type baseType = givenType.BaseType;
            if (baseType == null) return false;
            return IsAssignableToGenericType(baseType, genericType);
        }
    }
