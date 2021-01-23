    public class NoDefaultValueContractResolver : DefaultContractResolver
    {
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        static NoDefaultValueContractResolver instance;
        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static NoDefaultValueContractResolver() { instance = new NoDefaultValueContractResolver(); }
        public static NoDefaultValueContractResolver Instance { get { return instance; } }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (property.AttributeProvider.GetAttributes(typeof(DefaultValueAttribute), true).Any())
            {
                property.DefaultValue = property.PropertyType.GetDefaultValue();
            }
            return property;
        }
    }
    public static class TypeExtensions
    {
        public static object GetDefaultValue(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            if (!type.IsValueType || Nullable.GetUnderlyingType(type) != null)
                return null;
            return Activator.CreateInstance(type, true);
        }
    }
