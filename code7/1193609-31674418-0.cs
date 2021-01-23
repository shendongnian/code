    public class Sensor {
        public bool Active { get; set; }
        [JsonProperty(PropertyName = "_description")]
        public bool Description { get; set; }
        /* and so on */
    }
