    [JsonConverter(typeof(FluffDataConverter))]
    public class Data
    {
        public List<Thing> Things { get; set; }
    }
