    public static class JurisdictionList
    {
        public const string NSW = "New South Wales";
        public const string NT = "Northern Territory";
        public const string QLD = "Queensland";
        public const string SA = "South Australia";
        public const string TAS = "Tasmania";
        public const string VIC = "Victoria";
        public const string WA = "Western Australia";
     
        private static readonly Dictionary<string, string> CodeToName =
            typeof(JurisdictionList)
                .GetTypeInfo()
                .DeclaredFields
                .Where(f => f.FieldType == typeof(string))
                .ToDictionary(f => f.Name, f => f.GetValue(null));
    
        private static readonly Dictionary NameToCode =
            CodeToName.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
    
        // Methods using the dictionaries here
    }
