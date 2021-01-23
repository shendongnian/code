    public class PascalCaseToUnderscoreContractResolver : DefaultContractResolver
    {
        protected PascalCaseToUnderscoreContractResolver() : base() { }
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        static PascalCaseToUnderscoreContractResolver instance;
        // Using an explicit static constructor enables lazy initialization.
        static PascalCaseToUnderscoreContractResolver() { instance = new PascalCaseToUnderscoreContractResolver(); }
        public static PascalCaseToUnderscoreContractResolver Instance { get { return instance; } }
        static string PascalCaseToUnderscore(string name)
        {
            if (name == null || name.Length < 1)
                return name;
            var sb = new StringBuilder(name);
            for (int i = 0; i < sb.Length; i++)
            {
                var ch = char.ToLowerInvariant(sb[i]);
                if (ch != sb[i])
                {
                    if (i > 0) // Handle flag delimiters
                    {
                        sb.Insert(i, '_');
                        i++;
                    }
                    sb[i] = ch;
                }
            }
            return sb.ToString();
        }
        protected override string ResolvePropertyName(string propertyName)
        {
            return PascalCaseToUnderscore(propertyName);
        }
    }
