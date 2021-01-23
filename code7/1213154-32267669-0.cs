    public class Shards
    {
        public int total { get; set; }
        public int successful { get; set; }
        public int failed { get; set; }
    }
    public class Nested
    {
        public string field { get; set; }
        public int offset { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)] // Do not write the null value
        public Nested _nested { get; set; }
    }
    public class Value
    {
        public string pid { get; set; }
        public List<string> val { get; set; }
    }
    public class Source
    {
        public string pname { get; set; }
        public List<Value> values { get; set; }
    }
    public class Hit2
    {
        public string _index { get; set; }
        public string _type { get; set; }
        public string _id { get; set; }
        public Nested _nested { get; set; }
        public double _score { get; set; }
        public Source _source { get; set; }
    }
    public class Hits2
    {
        public int total { get; set; }
        public double max_score { get; set; }
        public List<Hit2> hits { get; set; }
    }
    public class InnerHits
    {
        public Hits2 hits { get; set; }
    }
    public class Hit
    {
        public string _index { get; set; }
        public string _type { get; set; }
        public string _id { get; set; }
        public double _score { get; set; }
        public Dictionary<string, InnerHits> inner_hits { get; set; }
    }
    public class Hits
    {
        public int total { get; set; }
        public double max_score { get; set; }
        public List<Hit> hits { get; set; }
    }
    public class RootObject
    {
        public int took { get; set; }
        public bool timed_out { get; set; }
        public Shards _shards { get; set; }
        public Hits hits { get; set; }
    }
