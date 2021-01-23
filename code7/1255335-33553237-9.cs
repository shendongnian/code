    [JsonConverter(typeof(AddressValueConverter))]
    public class AddressValue
    {
        public string Label { get; set; }
        public string Value { get; set; }
    }
    public class RootObject
    {
        [JsonProperty("value")]
        public List<AddressValue> Value { get; set; }
    }
