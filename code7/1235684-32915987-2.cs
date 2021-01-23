    public class CampaignModel
    {
        [JsonProperty(Order = 1)]
        public string Checked { get; set; }
        [JsonProperty(Order = 2)]
        public int CampaignId { get; set; }
        [JsonProperty(Order = 3)]
        public string Name { get; set; }
        [JsonProperty(Order = 4)]
        public string Market { get; set; }
        [JsonProperty(Order = 5)]
        public string Type { get; set; }
        [JsonProperty(Order = 6)]
        public bool IsActive { get; set; }
        [JsonProperty(Order = 7)]
        public bool Active { get; set; }
    }
