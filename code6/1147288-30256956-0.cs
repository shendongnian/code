    public class Team
    {
        public int Team_Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Url { get; set; }
        //other properties
        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
    }
