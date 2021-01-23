    public class CrmAuthReq
    {
        [JsonProperty("user_auth")]
        public CrmAuth Auth { get; set; }
    }
    public class CrmAuth
    {
        [JsonProperty("user_name")]
        public string Name { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
