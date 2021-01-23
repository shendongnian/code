    public class CamelCaseIgnoringPropertyJsonResolver : CamelCasePropertyNamesContractResolver
    {
        private readonly string _propertyToIgnore;
        // the argument here could be improved to accept an expression. (http://stackoverflow.com/questions/2789504/get-the-property-as-a-string-from-an-expressionfunctmodel-tproperty)
        public CamelCaseIgnoringPropertyJsonResolver(string propertyToIgnore)
        {
            _propertyToIgnore = propertyToIgnore;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
            // only serialize properties that start with the specified character
            properties = properties.Where(p => !p.PropertyName.Equals(_propertyToIgnore, StringComparison.OrdinalIgnoreCase)).ToList();
            return properties;
        }
    }
