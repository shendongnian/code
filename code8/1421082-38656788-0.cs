    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        public static readonly ShouldSerializeContractResolver Instance = new ShouldSerializeContractResolver();
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (property.AttributeProvider.GetAttributes(typeof (IgnoreMeAttribute), false).Any())
                property.ShouldSerialize = instance => false;
            return property;
        }
    }
