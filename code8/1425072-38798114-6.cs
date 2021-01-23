    public class UntypedToTypedPropertyContractResolver : DefaultContractResolver
    {
        readonly UntypedToTypedValueConverter converter = new UntypedToTypedValueConverter();
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        // See also https://stackoverflow.com/questions/33557737/does-json-net-cache-types-serialization-information
        static UntypedToTypedPropertyContractResolver instance;
        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static UntypedToTypedPropertyContractResolver() { instance = new UntypedToTypedPropertyContractResolver(); }
        public static UntypedToTypedPropertyContractResolver Instance { get { return instance; } }
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            var contract = base.CreateObjectContract(objectType);
            foreach (var property in contract.Properties.Concat(contract.CreatorParameters))
            {
                if (property.PropertyType == typeof(object)
                    && property.Converter == null)
                {
                    property.Converter = property.MemberConverter = converter;
                }
            }
            return contract;
        }
    }
