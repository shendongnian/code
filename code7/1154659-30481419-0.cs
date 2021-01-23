    public class Customer
    {
        [JsonProperty(Required = Required.Always)]
        public string Name{ get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Address{ get; set; }
    }
