    using Newtonsoft.Json;
    public class WebHookResponseModel
    {
        public Entry[] entry { get; set; }
        [JsonProperty("object")]
        public string _object { get; set; }
    }
    public class Entry
    {
        public Change[] changes { get; set; }
        public string id { get; set; }
        public int time { get; set; }
    }
    public class Change
    {
        public string field { get; set; }
        public Value value { get; set; }
    }
    public class Value
    {
        public int ad_id { get; set; }
        public long form_id { get; set; }
        public long leadgen_id { get; set; }
        public int created_time { get; set; }
        public long page_id { get; set; }
        public int adgroup_id { get; set; }
    }
