    public class DeliveryStatus
    {
        public object message { get; set; }
        public int code { get; set; }
        public string description { get; set; }
        [JsonProperty("session-seconds")]
        public int session_seconds { get; set; }
    }
    
    public class Item
    {
        [JsonProperty("delivery-status")]
        public DeliveryStatus delivery_status { get; set; }
        public string @event { get; set; }
        [JsonProperty("log-level")]
        public string log_level { get; set; }
        public string recipient { get; set; }
    }
    public class RootObject
    {
        public List<Item> items { get; set; }
    }
    
    public static void Main(string[] args)
    {
            string json = @"{
      ""items"": [{
        ""delivery-status"": {
                    ""message"": null,
          ""code"": 605,
          ""description"": ""Not delivering to previously bounced address"",
          ""session-seconds"": 0
        },
        ""event"": ""failed"",
        ""log-level"": ""error"",
        ""recipient"": ""test@test.com""
      }]
    }";
        RootObject r = JsonConvert.DeserializeObject<RootObject>(json);
    }
