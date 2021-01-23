    public class YourClass
    {
        [JsonProperty("@@hello")]
        public string Hello{ get; set; }
        [JsonProperty("#world")]
        public string World{ get; set; }
    }
    var model= JsonConvert.DeserializeObject<YourClass>(jsonstring);
