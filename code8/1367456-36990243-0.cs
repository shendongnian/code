    public class HttpUnauthorizedWithDefaultText : HttpUnauthorizedResult
    {
        public HttpUnauthorizedWithDefaultText() : base("Some default text")
        {
        }
    }
