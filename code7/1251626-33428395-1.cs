    public class RootObject
    {
        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }
    
    public class Result
    {
        [JsonProperty("series")]
        public List<Series> Series { get; set; }
    }
    
    public class Series
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("columns")]
        public List<string> ColumnNames { get; set; }
        [JsonProperty("values")]
        public List<List<object>> Points { get; set; }
    }
