    public JsonClass {
        [JsonProperty(PropertyName="id")]
        public int Id { get; set; }
        // Do this for each property you want to map.
        [JsonProperty(PropertyName="name")]
        public int Name { get; set; }
        [JsonProperty(PropertyName="type")]
        public MessageType Message { get; set; }
    }
    public class MessageType {
        [JsonProperty(PropertyName="id")]
        public int Id { get; set; }
        // etc...
    }
