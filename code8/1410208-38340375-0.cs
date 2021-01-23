    public class UntypedToTypedValueContractResolver : DefaultContractResolver
    {
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        // See also https://stackoverflow.com/questions/33557737/does-json-net-cache-types-serialization-information
        static UntypedToTypedValueContractResolver instance;
        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static UntypedToTypedValueContractResolver() { instance = new UntypedToTypedValueContractResolver(); }
        public static UntypedToTypedValueContractResolver Instance { get { return instance; } }
        protected override JsonDictionaryContract CreateDictionaryContract(Type objectType)
        {
            var contract = base.CreateDictionaryContract(objectType);
            if (contract.DictionaryValueType == typeof(object) && contract.ItemConverter == null)
            {
                contract.ItemConverter = new UntypedToTypedValueConverter();
            }
            return contract;
        }
    }
    class UntypedToTypedValueConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException("This converter should only be applied directly via ItemConverterType, not added to JsonSerializer.Converters");
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize(reader, objectType);
            if (value is TypeWrapper)
            {
                return ((TypeWrapper)value).ObjectValue;
            }
            return value;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (serializer.TypeNameHandling == TypeNameHandling.None)
            {
                Debug.WriteLine("ObjectItemConverter used when serializer.TypeNameHandling == TypeNameHandling.None");
                serializer.Serialize(writer, value);
            }
            // Handle a couple of simple primitive cases where a type wrapper is not needed
            else if (value is string)
            {
                writer.WriteValue((string)value);
            }
            else if (value is bool)
            {
                writer.WriteValue((bool)value);
            }
            else
            {
                var contract = serializer.ContractResolver.ResolveContract(value.GetType());
                if (contract is JsonPrimitiveContract)
                {
                    var wrapper = TypeWrapper.CreateWrapper(value);
                    serializer.Serialize(writer, wrapper, typeof(object));
                }
                else
                {
                    serializer.Serialize(writer, value);
                }
            }
        }
    }
    public abstract class TypeWrapper
    {
        protected TypeWrapper() { }
        [JsonIgnore]
        public abstract object ObjectValue { get; }
        public static TypeWrapper CreateWrapper<T>(T value)
        {
            if (value == null)
                return new TypeWrapper<T>();
            var type = value.GetType();
            if (type == typeof(T))
                return new TypeWrapper<T>(value);
            // Return actual type of subclass
            return (TypeWrapper)Activator.CreateInstance(typeof(TypeWrapper<>).MakeGenericType(type), value);
        }
    }
    public sealed class TypeWrapper<T> : TypeWrapper
    {
        public TypeWrapper() : base() { }
        public TypeWrapper(T value)
            : base()
        {
            this.Value = value;
        }
        public override object ObjectValue { get { return Value; } }
        public T Value { get; set; }
    }
