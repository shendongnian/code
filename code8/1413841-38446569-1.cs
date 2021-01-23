    public class AuthenticationResponse : Response
    {
        [DeserializeAs(Name = "OWASP_CSRF_TOKEN")]
        public OWaspCsrfToken CsrfToken { get; set; }
        public struct OWaspCsrfToken
        {
            [DeserializeAs(Name = "token")]
            public string Token { get; set; }
        }
    }
