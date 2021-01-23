    public class GetAllCallsResponse : PlivoResponse
    {
    
        [DeserializeAs(Name = "meta")]
        public GetAllCallsMeta Meta { get; set; }
        [DeserializeAs(Name = "objects")]
        public List<datas> Calls { get; set; }
    }
    public class datas
    {
        [DeserializeAs(Name = "bill_duration")]
        public int bill_duration { get; set; }
        [DeserializeAs(Name = "billed_duration")]
        public int billed_duration { get; set; }
        [DeserializeAs(Name = "call_direction")]
        public string call_direction { get; set; }
        [DeserializeAs(Name = "call_duration")]
        public int call_duration { get; set; }
        [DeserializeAs(Name = "call_uuid")]
        public string call_uuid { get; set; }
        [DeserializeAs(Name = "end_time")]
        public string end_time { get; set; }
        [DeserializeAs(Name = "from_number")]
        public string from_number { get; set; }
        [DeserializeAs(Name = "parent_call_uuid")]
        public string parent_call_uuid { get; set; }
        [DeserializeAs(Name = "resource_uri")]
        public string resource_uri { get; set; }
        [DeserializeAs(Name = "to_number")]
        public string to_number { get; set; }
        [DeserializeAs(Name = "total_amount")]
        public string total_amount { get; set; }
        [DeserializeAs(Name = "total_rate")]
        public string total_rate { get; set; }
    }
