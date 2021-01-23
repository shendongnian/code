    [DataContract]
    public class Evaluation
    {
        public int Id { get; set; }
        [JsonProperty("avg")]
        public string Average { get; set; }
    
        public string Median { get; set; }
    
        public int TeacherId { get; set; }
        [JsonProperty("evalType")]
        public int EvaluationType { get; set; }
    }
