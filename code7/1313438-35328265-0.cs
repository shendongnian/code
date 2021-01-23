    /// <summary>
    /// Contract resolver to ignore properties of a single given type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class IgnoreTypePropertiesContractResolver<T> : IgnoreTypePropertiesContractResolver
    {
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        static IgnoreTypePropertiesContractResolver<T> instance;
        static IgnoreTypePropertiesContractResolver() { instance = new IgnoreTypePropertiesContractResolver<T>(); }
        public static IgnoreTypePropertiesContractResolver<T> Instance { get { return instance; } }
        IgnoreTypePropertiesContractResolver() : base(new[] { typeof(T) }) { }
    }
    /// <summary>
    /// Contract resolver to ignore properties of any number of given types.
    /// </summary>
    public class IgnoreTypePropertiesContractResolver : DefaultContractResolver
    {
        readonly HashSet<Type> toIgnore;
        readonly HashSet<Type> toIgnoreAndBase;
        public IgnoreTypePropertiesContractResolver(IEnumerable<Type> toIgnore)
        {
            if (toIgnore == null)
                throw new ArgumentNullException();
            this.toIgnore = new HashSet<Type>(toIgnore);
            this.toIgnoreAndBase = new HashSet<Type>(toIgnore.SelectMany(t => t.BaseTypesAndSelf()));
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var list = base.CreateProperties(type, memberSerialization);
            if (type.BaseTypesAndSelf().Any(t => toIgnore.Contains(t)))
            {
                var filtered = list.Where(p => !toIgnoreAndBase.Contains(p.DeclaringType)).ToList();
                return filtered;
            }
            return list;
        }
    }
    public static class TypeExtensions
    {
        public static IEnumerable<Type> BaseTypesAndSelf(this Type type)
        {
            while (type != null)
            {
                yield return type;
                type = type.BaseType;
            }
        }
    }
