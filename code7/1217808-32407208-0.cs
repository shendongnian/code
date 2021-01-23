    public class SkipSpecifiedContractResolver : DefaultContractResolver
    {
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        static SkipSpecifiedContractResolver instance;
        static SkipSpecifiedContractResolver() { instance = new SkipSpecifiedContractResolver(); }
        public static SkipSpecifiedContractResolver Instance { get { return instance; } }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
            ILookup<string, JsonProperty> lookup = null;
            foreach (var property in properties)
            {
                if (property.GetIsSpecified != null && property.SetIsSpecified != null)
                {
                    var name = property.UnderlyingName + "Specified";
                    lookup = lookup ?? properties.ToLookup(p => p.UnderlyingName);
                    var specified = lookup[name].SingleOrDefault();
                    if (specified != null)
                        specified.Ignored = true;
                }
            }
            return properties;
        }
    }
