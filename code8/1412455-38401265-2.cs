    class SimpleClassWithRegex
    {
        [JsonConverter(typeof(ImprovedRegexConverter))]
        public Regex RegProp { get; set; }
    }
