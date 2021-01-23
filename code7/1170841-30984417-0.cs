    [JsonObject(ItemRequired = Required.Always)]
    public class Hamster
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]
        [JsonProperty(Required = Required.Default)]
        public string FullName { get { return FirstName + LastName; }}
    }
