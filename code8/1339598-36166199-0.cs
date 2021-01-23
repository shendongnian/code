    public class ResponseStatus
    {
        public string code { get; set; }
        public string message { get; set; }
        public string messageDetails { get; set; }
    }
    public class AccessTokenResponse
    {
        public string token { get; set; }
        public ResponseStatus responseStatus { get; set; }
    }
    public class Response
    {
        public AccessTokenResponse accessTokenResponse { get; set; }
    }
