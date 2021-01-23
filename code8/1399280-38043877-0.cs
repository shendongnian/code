    public class LandingPageRouter : IRouter
    {
        private readonly IRouter _router;
        public LandingPageRouter(IRouter router)
        {
            _router = router;
        }
        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }
        public Task RouteAsync(RouteContext context)
        {
            var requestPath = context.HttpContext.Request.Path.Value;
            if (!string.IsNullOrEmpty(requestPath) && requestPath[0] == '/')
            {
                requestPath = requestPath.Substring(1);
            }
            var pagefound = GetPages().Any(x => x == requestPath);
            if (pagefound)
            {
                //TODO: Handle querystrings
                var routeData = new RouteData();
                routeData.Values["controller"] = "LandingPage";
                routeData.Values["action"] = "Index";
                context.RouteData = routeData;
                return _router.RouteAsync(context);
            }
            return Task.FromResult(0);
        }
        private IEnumerable<string> GetPages()
        {
            //TODO: pull from database
            return new List<string> { "page-url-title", "another-dynamic-url" };
        }
    }
