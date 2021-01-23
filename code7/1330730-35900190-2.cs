    public class ExtensionNameMappingContractResolver : IContractResolver
    {
        readonly IContractResolver baseResolver;
        readonly Regex regex;
        readonly string replacement;
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        static ExtensionNameMappingContractResolver removeNonAlphanumericCharactersInstance;
        static ExtensionNameMappingContractResolver()
        {
            // Regex is from https://stackoverflow.com/questions/8779189/how-do-i-strip-non-alphanumeric-characters-including-spaces-from-a-string
            removeNonAlphanumericCharactersInstance = new ExtensionNameMappingContractResolver(new DefaultContractResolver(), new Regex(@"[^\p{L}\p{N}]+"), "");
        }
        public static ExtensionNameMappingContractResolver RemoveNonAlphanumericCharactersInstance { get { return removeNonAlphanumericCharactersInstance; } }
        public ExtensionNameMappingContractResolver(IContractResolver baseResolver, Regex regex, string replacement)
        {
            if (regex == null || replacement == null || baseResolver == null)
                throw new ArgumentNullException();
            this.regex = regex;
            this.replacement = replacement;
            this.baseResolver = baseResolver;
        }
        #region IContractResolver Members
        public JsonContract ResolveContract(Type type)
        {
            var contract = baseResolver.ResolveContract(type);
            if (contract is JsonObjectContract)
            {
                var objContract = (JsonObjectContract)contract;
                if (objContract.ExtensionDataSetter != null)
                {
                    var oldSetter = objContract.ExtensionDataSetter;
                    objContract.ExtensionDataSetter = (o, key, value) =>
                    {
                        var newKey = regex.Replace(key, replacement);
                        oldSetter(o, newKey, value);
                    };
                }
            }
            return contract;
        }
        #endregion
    }
