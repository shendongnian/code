    public class ResponseObject
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("LoginUrl")]
        public string LoginUrl { get; set; }
        [JsonProperty("LogoutUrl")]
        public string LogoutUrl { get; set; }
        [JsonProperty("ImageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty("EmailAddressSuffixes")]
        public IList<string> EmailAddressSuffixes { get; set; }
    }
