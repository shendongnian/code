    public interface ISiteNameProvider
    {
        String SiteName { get; }
    }
    public class HttpContextSiteNameProvider : ISiteNameProvider
    {
        public HttpContextSiteNameProvider(HttpContextBase context)
        {
            this._context = context;
        }
        private readonly HttpContextBase _context; 
        public String SiteName 
        {
            get 
            {
                return this._context.Request.Url.Host;
            }
        }
    }
