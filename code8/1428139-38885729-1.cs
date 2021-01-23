    public class CorrelationGroup
    {
        [Keyword]
        public string Type { get; set; }
    
        [Keyword(Name = "type_value")]
        public string TypeValue { get; set; }
    
        public List<int> Groups { get; set; }
    }
