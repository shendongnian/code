    public class TestContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (typeof(BaseClass).IsAssignableFrom(property.PropertyType))
            {
                var converter = new TestConverter();
                property.Converter = converter;
                property.MemberConverter  = converter;
            }
            return property;
        }
    }
