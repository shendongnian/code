    class Query
    {
        [JsonProperty("where")]
        public Clause Where { get; set; }
    }
    class Clause
    {
        [JsonProperty("operator")]
        public string Operator { get; set; }
        [JsonProperty("left")]
        public Clause Left { get; set; }
        [JsonProperty("right")]
        public Clause Right { get; set; }
        [JsonProperty("$fieldref")]
        public string FieldRef { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
