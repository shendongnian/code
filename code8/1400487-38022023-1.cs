    public class IgnoreDataMemberContractResolver : DefaultContractResolver
    {
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        // See also https://stackoverflow.com/questions/33557737/does-json-net-cache-types-serialization-information
        static IgnoreDataMemberContractResolver instance;
        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static IgnoreDataMemberContractResolver() { instance = new IgnoreDataMemberContractResolver(); }
        public static IgnoreDataMemberContractResolver Instance { get { return instance; } }
        protected override JsonProperty CreateProperty(System.Reflection.MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (memberSerialization == MemberSerialization.OptIn)
            {
                // Preserve behavior that [DataMember] supersedes [IgnoreDataMember] when applied in the same type
                // but not when appled to a base type.
                if (!property.Ignored
                    && property.AttributeProvider.GetAttributes(typeof(IgnoreDataMemberAttribute), false).Any()
                    && !property.AttributeProvider.GetAttributes(typeof(DataMemberAttribute), true).Any())
                {
                    property.Ignored = true;
                }
            }
            return property;
        }
    }
