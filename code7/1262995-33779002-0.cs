    public class HttpContextWrapper
    {
        private readonly IHttpContext _httpContext;
        public HttpContextWrapper()
        {
            _httpContext = HttpContext.Current;
        }
        public HttpContextWrapper(IHttpContext injectedContext)
        {
            _httpContext = injectedContext;
        }
        public string GetName()
        {
            _httpContext.Current.User.Identity.Name;
        }
    }
