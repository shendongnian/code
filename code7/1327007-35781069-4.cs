    public class DataContractForCollectionsResolver : DefaultContractResolver
    {
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        static DataContractForCollectionsResolver instance;
        static DataContractForCollectionsResolver() { instance = new DataContractForCollectionsResolver(); }
        public static DataContractForCollectionsResolver Instance { get { return instance; } }
        protected DataContractForCollectionsResolver() : base() { }
        protected override JsonContract CreateContract(Type objectType)
        {
            var t = (Nullable.GetUnderlyingType(objectType) ?? objectType);
            if (!t.IsPrimitive 
                && t != typeof(string)
                && !t.IsArray
                && typeof(IEnumerable).IsAssignableFrom(t) 
                && !t.GetCustomAttributes<JsonContainerAttribute>().Any())
            {
                if (t.GetCustomAttributes<DataContractAttribute>().Any())
                    return base.CreateObjectContract(objectType);
            }
            return base.CreateContract(objectType);
        }
    }
