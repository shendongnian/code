    class TestObject {
        public int A { get; set; }
        [JsonProperty] private int alpha { set => A = value; }
        [JsonProperty] private int omega { set => A = value; }
    }
