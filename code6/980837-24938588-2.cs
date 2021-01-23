    public class MyRoute: Route
    {
        public MyRoute()
            : base("{*catchall}", new MvcRouteHandler())
        {
        }
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var rd = base.GetRouteData(httpContext);
            if (rd == null)
            {
                // we do not have a match for {*catchall}, although this is very
                // unlikely to ever happen :-)
                return null;
            }
            var segments = httpContext.Request.Url.AbsolutePath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (segments.Length < 4)
            {
                // we do not have the minimum number of segments
                // in the url to have a match
                return null;
            }
            if (!string.Equals("items", segments[1], StringComparison.InvariantCultureIgnoreCase) &&
                !string.Equals("items", segments[2], StringComparison.InvariantCultureIgnoreCase))
            {
                // we couldn't find "items" at the expected position in the url
                return null;
            }
            // at this stage we know that we have a match and can start processing
            // Feel free to find a faster and more readable split here
            string repository = string.Join("/", segments.TakeWhile(segment => !string.Equals("items", segment, StringComparison.InvariantCultureIgnoreCase)));
            string path = string.Join("/", segments.Reverse().TakeWhile(segment => !string.Equals("items", segment, StringComparison.InvariantCultureIgnoreCase)).Reverse());
            rd.Values["controller"] = "items";
            rd.Values["action"] = "index";
            rd.Values["repository"] = repository;
            rd.Values["path"] = path;
            return rd;
        }
    }
