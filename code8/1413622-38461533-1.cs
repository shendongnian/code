    public class CallDetails
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("call_id")]
        public string CallId { get; set; }
        [JsonProperty("answered_time")]
        public string AnsweredTime { get; set; }
    }
