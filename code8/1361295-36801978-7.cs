    public static class JsonExtensions
    {
        public static IEnumerable<T> DeserializeNamedProperties<T>(Stream stream, string propertyName, JsonSerializerSettings settings = null, int? depth = null)
        {
            using (var textReader = new StreamReader(stream))
                foreach (var value in DeserializeNamedProperties<T>(textReader, propertyName, settings, depth))
                    yield return value;
        }
        public static IEnumerable<T> DeserializeNamedProperties<T>(TextReader textReader, string propertyName, JsonSerializerSettings settings = null, int? depth = null)
        {
            var serializer = JsonSerializer.CreateDefault(settings);
            using (var jsonReader = new JsonTextReader(textReader))
            {
                while (jsonReader.Read())
                {
                    if (jsonReader.TokenType == JsonToken.PropertyName
                        && (string)jsonReader.Value == propertyName
                        && depth == null || depth == jsonReader.Depth)
                    {
                        jsonReader.Read();
                        yield return serializer.Deserialize<T>(jsonReader);
                    }
                }
            }
        }
    }
    public class ArrayToSingleContractResolver : DefaultContractResolver
    {
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        static ArrayToSingleContractResolver instance;
        static ArrayToSingleContractResolver() { instance = new ArrayToSingleContractResolver(); }
        public static ArrayToSingleContractResolver Instance { get { return instance; } }
        readonly SimplePropertyArrayToSingleConverter simpleConverter = new SimplePropertyArrayToSingleConverter();
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var jsonProperty = base.CreateProperty(member, memberSerialization);
            if (jsonProperty.Converter == null && jsonProperty.MemberConverter == null)
            {
                if (jsonProperty.PropertyType.IsPrimitive 
                    || jsonProperty.PropertyType == typeof(string))
                {
                    jsonProperty.Converter = jsonProperty.MemberConverter = simpleConverter;
                }
                else if (jsonProperty.PropertyType != typeof(object)
                    && !typeof(IEnumerable).IsAssignableFrom(jsonProperty.PropertyType)
                    && !typeof(JToken).IsAssignableFrom(jsonProperty.PropertyType))
                {
                    jsonProperty.Converter = jsonProperty.MemberConverter = new ObjectPropertyArrayToSingleConverter(this, jsonProperty.PropertyType);
                }
            }
            return jsonProperty;
        }
    }
    public static class JsonContractExtensions
    {
        public static bool? IsArrayContract(this JsonContract contract)
        {
            if (contract == null)
                throw new ArgumentNullException();
            if (contract is JsonArrayContract)
                return true;
            else if (contract is JsonLinqContract)
                return null; // Could be an object or an array.
            else
                return false;
        }
    }
    class SimplePropertyArrayToSingleConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            while (reader.TokenType == JsonToken.Comment)
                reader.Read();
            if (reader.TokenType == JsonToken.Null)
                return null;
            var contract = serializer.ContractResolver.ResolveContract(objectType);
            bool hasValue = false;
            if (reader.TokenType == JsonToken.StartArray)
            {
                while (reader.Read())
                {
                    switch (reader.TokenType)
                    {
                        case JsonToken.Comment:
                            break;
                        case JsonToken.EndArray:
                            return UndefaultValue(objectType, existingValue, contract);
                        default:
                            if (hasValue)
                                throw new JsonSerializationException("Too many values at path: " + reader.Path);
                            existingValue = ReadItem(reader, objectType, existingValue, serializer, contract);
                            hasValue = true;
                            break;
                    }
                }
                // Should not come here.
                throw new JsonSerializationException("Unclosed array at path: " + reader.Path);
            }
            else
            {
                existingValue = ReadItem(reader, objectType, existingValue, serializer, contract);
                return UndefaultValue(objectType, existingValue, contract);
            }
        }
        private static object UndefaultValue(Type objectType, object existingValue, JsonContract contract)
        {
            if (existingValue == null && objectType.IsValueType && Nullable.GetUnderlyingType(objectType) == null)
                existingValue = contract.DefaultCreator();
            return existingValue;
        }
        private static object ReadItem(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer, JsonContract contract)
        {
            if (contract is JsonPrimitiveContract || existingValue == null)
            {
                existingValue = serializer.Deserialize(reader, objectType);
            }
            else
            {
                serializer.Populate(reader, existingValue);
            }
            return existingValue;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            if (value != null)
                serializer.Serialize(writer, value);
            writer.WriteEndArray();
        }
    }
    class ObjectPropertyArrayToSingleConverter : SimplePropertyArrayToSingleConverter
    {
        readonly Type propertyType;
        readonly IContractResolver resolver;
        int canConvert = -1;
        public ObjectPropertyArrayToSingleConverter(IContractResolver resolver, Type propertyType)
            : base()
        {
            if (propertyType == null || resolver == null)
                throw new ArgumentNullException();
            this.propertyType = propertyType;
            this.resolver = resolver;
        }
        int GetIsEnabled()
        {
            var contract = resolver.ResolveContract(propertyType);
            return contract.IsArrayContract() == false ? 1 : 0;
        }
        bool IsEnabled
        {
            get
            {
                // We need to do this in a lazy fashion since recursive calls to resolve contracts while creating a contract are problematic.
                if (canConvert == -1)
                    Interlocked.Exchange(ref canConvert, GetIsEnabled());
                return canConvert == 1;
            }
        }
        public override bool CanRead { get { return IsEnabled; } }
        public override bool CanWrite { get { return IsEnabled; } }
    }
