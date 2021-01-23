    public class ReplacePipeHttpRoute : System.Web.Http.Routing.HttpRoute
    {
        public ReplacePipeHttpRoute(string routeTemplate, object defaults)
            : base(routeTemplate, new HttpRouteValueDictionary(defaults))
        { }
        // OPTIONAL: Add additional overloads for constraints, dataTokens, and handler
        // Converts | to / on incoming route
        public override IHttpRouteData GetRouteData(string virtualPathRoot, System.Net.Http.HttpRequestMessage request)
        {
            var routeData = base.GetRouteData(virtualPathRoot, request);
            // RouteData will be null if the URL or constraint didn't match
            if (routeData != null)
            {
                var newValues = new HttpRouteValueDictionary();
                foreach (var r in routeData.Values)
                {
                    newValues.Add(r.Key, r.Value.ToString().Replace("|", "/"));
                }
                routeData = new HttpRouteData(this, newValues);
            }
            return routeData;
        }
        // Converts / to | on outgoing route (URLs that are generated from WebApi)
        public override IHttpVirtualPathData GetVirtualPath(System.Net.Http.HttpRequestMessage request, IDictionary<string, object> values)
        {
            var newValues = new Dictionary<string, object>();
            if (values != null)
            {
                foreach (var r in values)
                {
                    // Encode pipe as outlined in: http://www.tutorialspoint.com/html/html_url_encoding.htm
                    newValues.Add(r.Key, r.Value.ToString().Replace("/", "%7c"));
                }
            }
            return base.GetVirtualPath(request, newValues);
        }
    }
