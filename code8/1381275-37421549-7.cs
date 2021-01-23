    public class ConstructorParametersRequiredContractResolver : DefaultContractResolver
    {
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        // See also https://stackoverflow.com/questions/33557737/does-json-net-cache-types-serialization-information
        static ConstructorParametersRequiredContractResolver instance;
        static ConstructorParametersRequiredContractResolver() { instance = new ConstructorParametersRequiredContractResolver(); }
        public static ConstructorParametersRequiredContractResolver Instance { get { return instance; } }
        protected override JsonProperty CreatePropertyFromConstructorParameter(JsonProperty matchingMemberProperty, ParameterInfo parameterInfo)
        {
            var property = base.CreatePropertyFromConstructorParameter(matchingMemberProperty, parameterInfo);
            if (property != null && matchingMemberProperty != null)
            {
                var required = matchingMemberProperty.Required;
                if (required == Required.Default)
                {
                    if (matchingMemberProperty.PropertyType != null && (matchingMemberProperty.PropertyType.IsValueType && Nullable.GetUnderlyingType(matchingMemberProperty.PropertyType) == null))
                    {
                        required = Required.Always;
                    }
                    else
                    {
                        required = Required.AllowNull;
                    }
                    // It turns out to be necessary to mark the original matchingMemberProperty as required.
                    property.Required = matchingMemberProperty.Required = required;
                }
            }
            return property;
        }
    }
