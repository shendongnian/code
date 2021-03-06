    public class ShouldDeserializeContractResolver : DefaultContractResolver
    {
        public static new readonly ShouldDeserializeContractResolver Instance = new ShouldDeserializeContractResolver();
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            MethodInfo shouldDeserializeMethodInfo = member.DeclaringType.GetMethod("ShouldDeserialize" + member.Name);
            if (shouldDeserializeMethodInfo != null)
            {
                property.ShouldDeserialize = o => { return (bool)shouldDeserializeMethodInfo.Invoke(o, null); };
            }
            return property;
        }
    }
    public class ShouldDeserializeTestClass
    {
        [JsonExtensionData]
        public IDictionary<string, JToken> ExtensionData { get; set; }
        public bool HasName { get; set; }
        public string Name { get; set; }
        public bool ShouldDeserializeName()
        {
            return HasName;
        }
    }
