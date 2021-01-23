    public class RouteTemplateMiddleware : OwinMiddleware
    {
        private const string HttpRouteDataKey = "MS_SubRoutes";
        private readonly HttpRouteCollection _routes;
        public RouteTemplateMiddleware(OwinMiddleware next, HttpRouteCollection routes) : base(next)
        {
            _routes = routes;
        }
        public override async Task Invoke(IOwinContext context)
        {
            var routeData = _routes.GetRouteData(new HttpRequestMessage(new HttpMethod(context.Request.Method), context.Request.Uri));
            var routeValues = routeData?.Values as System.Web.Http.Routing.HttpRouteValueDictionary;
            var route = routeValues?[HttpRouteDataKey] as System.Web.Http.Routing.IHttpRouteData[];
            var routeTemplate = route?[0].Route.RouteTemplate;
            // ... do something the route template
            await Next.Invoke(context);
        }
    }
