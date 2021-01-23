    class Query
    {
        public Clause Where { get; set; }
    }
    class Clause
    {
        public string Operator { get; set; }
        public Clause Left { get; set; }
        public Clause Right { get; set; }
        [JsonProperty("$fieldref")]
        public string FieldRef { get; set; }
        public string Value { get; set; }
    }
