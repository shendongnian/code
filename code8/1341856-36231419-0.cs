    using Nest;
    using Newtonsoft.Json;
    [ElasticsearchType(Name = "company")]
    public class Company
    {
        public string Name { get; set; }
    
        [String(Ignore = true)]
        public string IgnoreViaAttribute { get; set; }
        public string IgnoreViaSettings { get;set; }
        [JsonIgnore]
        public string IgnoreViaSerializerSpecificAttribute { get; set; }
    }
