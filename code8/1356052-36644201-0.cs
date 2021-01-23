    public class Entity
    {
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("postcode")]
        public string PostCode { get; set; }
        [JsonProperty("membergroup")]
        public Dictionary<string, bool> MemberGroup { get; set; }
    }
