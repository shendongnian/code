    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        public new static readonly ShouldSerializeContractResolver Instance = new ShouldSerializeContractResolver();
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (property.DeclaringType == typeof(Province) && property.PropertyName == "Cities")
            {
                property.ShouldSerialize =
                    instance =>
                    {
                        Province province = (Province)instance;
                        return province != null && province.Count > 0;
                    };
            }
            return property;
        }
    }
