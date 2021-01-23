    public class RootObject
    {
        [JsonProperty(TypeNameHandling = TypeNameHandling.None)] // Do not emit array type information
        [JsonConverter(typeof(IgnoreArrayTypeConverter))]        // Swallow legacy type information
        public string[] Lanes { get; set; }
    }
