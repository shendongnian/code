    public class Queued_messages
    {
        [JsonProperty("queued_messages")]
        public string[] queued_messages { get; set; }
    }
    JObject jsonIDs = JObject.Parse(json);
    Queued_messages queuedMessageIDs = jsonIDs.ToObject<Queued_messages>();
