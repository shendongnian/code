    public class MyContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
            properties = properties.Where(p => p.PropertyName != "OmittedProperty").ToList();
            return properties;
        }
    }
