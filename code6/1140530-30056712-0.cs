    public class MockTourStep
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public TargetC Target { get; set; }
        public string Placement { get; set; }
    
        public enum TargetType
        {
            ElementName,
            QuerySelector
        }
    
        public class TargetC
        {
            [JsonConverter(typeof(StringEnumConverter))]
            public TargetType Type { get; set; }
    
            public string Value { get; set; } 
        }
    }
