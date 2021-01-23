    public class RootObject
    {
        [JsonProperty("d")]
        [JsonConverter(typeof(MaterialArrayConverter))]
        public List<Material> Materials { get; set; }
    }
