    class Child
    {
        [JsonMergeKey]
        [JsonProperty("Uuid")] // Replacement name for testing
        public Guid UUID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
