    public class JsonPropertyOverride
    {
        public string PropertyName { get; set; }
        public bool? Ignored { get; set; }
        // Others as required from http://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonPropertyAttribute.htm
        // Changing all value type properties to nullables.
    }
    public class OverrideContractResolver : DefaultContractResolver
    {
        readonly Dictionary<MemberInfo, JsonPropertyOverride> overrides; // A private copy for thread safety.
        public OverrideContractResolver(IDictionary<MemberInfo, JsonPropertyOverride> overrides)
            : base()
        {
            if (overrides == null)
                throw new ArgumentNullException();
            this.overrides = overrides.ToDictionary(p => p.Key, p => p.Value);
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (property != null)
            {
                JsonPropertyOverride attr;
                if (overrides.TryGetValue(member, out attr))
                {
                    if (attr.PropertyName != null)
                        property.PropertyName = ResolvePropertyName(attr.PropertyName);
                    if (attr.Ignored != null)
                        property.Ignored = attr.Ignored.Value;
                }
            }
            return property;
        }
    }
