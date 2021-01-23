    [System.AttributeUsage(System.AttributeTargets.Property | System.AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class LegacyDataMemberNamesAttribute : Attribute
    {
        public LegacyDataMemberNamesAttribute() : this(new string[0]) { }
        public LegacyDataMemberNamesAttribute(params string[] names)
        {
            this.Names = names;
        }
        public string [] Names { get; set; }
    }
    public class LegacyPropertyResolver : DefaultContractResolver
    {
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        static LegacyPropertyResolver instance;
        static LegacyPropertyResolver() { instance = new LegacyPropertyResolver(); }
        public static LegacyPropertyResolver Instance { get { return instance; } }
        protected LegacyPropertyResolver() : base() { }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
            for (int i = 0, n = properties.Count; i < n; i++)
            {
                var property = properties[i];
                if (!property.Writable)
                    continue;
                var attrs = property.AttributeProvider.GetAttributes(typeof(LegacyDataMemberNamesAttribute), true);
                if (attrs == null || attrs.Count == 0)
                    continue;
                // Little kludgy here: use MemberwiseClone to clone the JsonProperty.
                var clone = property.GetType().GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                foreach (var name in attrs.Cast<LegacyDataMemberNamesAttribute>().SelectMany(a => a.Names))
                {
                    if (properties.Any(p => p.PropertyName == name))
                    {
                        Debug.WriteLine("Duplicate LegacyDataMemberNamesAttribute: " + name);
                        continue;
                    }
                    var newProperty = (JsonProperty)clone.Invoke(property, new object[0]);
                    newProperty.Readable = false;
                    newProperty.PropertyName = name;
                    properties.Add(newProperty);
                }
            }
            return properties;
        }
    }
