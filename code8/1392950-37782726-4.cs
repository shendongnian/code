    public class MyTempModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [JsonExtensionData]
        public Dictionary<string, object> Countries { get; set; }
    }
    
    public class MyRealModel : Dictionary<int, CountryVM>
    {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
