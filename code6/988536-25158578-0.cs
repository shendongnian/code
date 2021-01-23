    public class DynamicContractResolver : DefaultContractResolver
    {
        private readonly string _propertyNameToExclude;
        public DynamicContractResolver(string propertyNameToExclude)
        {
            _propertyNameToExclude = propertyNameToExclude;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
            // only serializer properties that are not named after the specified property.
            properties =
                properties.Where(p => string.Compare(p.PropertyName, _propertyNameToExclude, true) != 0).ToList();
            return properties;
        }
    }
