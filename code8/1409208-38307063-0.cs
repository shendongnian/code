    public class OauthParameters
    {
        [FromQuery(Name = "client_id")]
        public string ClientId { get; set; }
    
        [FromQuery(Name = "response_type")]
        public string ResponseType { get; set; }
    
        [FromQuery(Name = "redirect_uri")]
        public string RedirectUri { get; set; }
    }
