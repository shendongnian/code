    public class UnitDetail
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
    }
    public class RootObject
    {
        [JsonProperty("odata.metadata")]
        public string odata_metadata { get; set; }
        public List<UnitDetail> value { get; set; }
    }
