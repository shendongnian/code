    public class IgnoreDictionaryTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.GetDictionaryKeyValueTypes().Count() == 1;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            existingValue = existingValue ?? serializer.ContractResolver.ResolveContract(objectType).DefaultCreator();
            var obj = JObject.Load(reader);
            obj.Remove("$type");
            using (var subReader = obj.CreateReader())
            {
                serializer.Populate(subReader, existingValue);
            }
            return existingValue;
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public static class TypeExtensions
    {
        /// <summary>
        /// Return all interfaces implemented by the incoming type as well as the type itself if it is an interface.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetInterfacesAndSelf(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException();
            if (type.IsInterface)
                return new[] { type }.Concat(type.GetInterfaces());
            else
                return type.GetInterfaces();
        }
        public static IEnumerable<Type[]> GetDictionaryKeyValueTypes(this Type type)
        {
            foreach (Type intType in type.GetInterfacesAndSelf())
            {
                if (intType.IsGenericType
                    && intType.GetGenericTypeDefinition() == typeof(IDictionary<,>))
                {
                    yield return intType.GetGenericArguments();
                }
            }
        }
    }
