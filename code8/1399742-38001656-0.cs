    public class DefaultValueCamelCaseContractResolver : DefaultValueContractResolver
    {
        public DefaultValueCamelCaseContractResolver(IEnumerable<KeyValuePair<Type, DefaultValueHandling>> overrides) : base(overrides) { }
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToCamelCase();
        }
    }
    public class DefaultValueContractResolver : DefaultContractResolver
    {
        readonly Dictionary<Type, DefaultValueHandling> overrides;
        public DefaultValueContractResolver(IEnumerable<KeyValuePair<Type, DefaultValueHandling>> overrides)
            : base()
        {
            if (overrides == null)
                throw new ArgumentNullException("overrides");
            this.overrides = overrides.ToDictionary(p => p.Key, p => p.Value);
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (property.DefaultValueHandling == null)
            {
                DefaultValueHandling handling;
                if (overrides.TryGetValue(property.PropertyType, out handling))
                    property.DefaultValueHandling = handling;
            }
            return property;
        }
    }
    public static class CamelCaseNameExtensions 
    {
        class CamelCaseNameResolver : CamelCasePropertyNamesContractResolver
        {
            // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
            static CamelCaseNameResolver() { }
            internal static readonly CamelCaseNameResolver Instance = new CamelCaseNameResolver();
            // Purely to make the protected method public.
            public string ToCamelCase(string propertyName)
            {
                return ResolvePropertyName(propertyName);
            }
        }
        public static string ToCamelCase(this string propertyName)
        {
            if (propertyName == null)
                return null;
            return CamelCaseNameResolver.Instance.ToCamelCase(propertyName);
        }
    }
