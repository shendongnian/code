    public class EvaluationRoute : Route
    {
        public EvaluationRoute(string url, object defaults)
            : base(url, new RouteValueDictionary(defaults), new MvcRouteHandler())
        {
        }
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var routeData = base.GetRouteData(httpContext);
            // If the underlying route doesn't match, it will return null,
            // so only work our magic if we have a match.
            if (routeData != null) {
                // Add the typeControl to the RouteValues collection, since
                // MVC doesn't do this automatically.
                string typeControl = httpContext.Request.QueryString["typeControl"];
                routeData.Values.Add("typeControl", typeControl);
            }
            return routeData;
        }
    }
