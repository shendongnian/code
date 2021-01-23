    public class EstimatedUse
    {
        public string ID { get; set; }
        public double estimatedType1 { get; set; }
        public double estimatedType2 { get; set; }
        public double totalEstimatedUse { get { return estimatedType1 + estimatedType2; }
    }
