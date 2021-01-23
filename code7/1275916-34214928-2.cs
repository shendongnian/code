    public class MyHttpControllerSelector : DefaultHttpControllerSelector
        {
            private HttpConfiguration _config;
    
            public MyHttpControllerSelector(HttpConfiguration configuration) : base(configuration)
            {
                _config = configuration;
            }
    
            public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
            {
                var routeData = request.GetRouteData();
                var routeTemplate = routeData.Route.RouteTemplate;
                if (routeTemplate.IndexOf("v2/values") != -1)
                {
                    return new HttpControllerDescriptor(
                        _config, "Values", 
                        typeof(WebApplication4.Controllers.V2.ValuesController));
                } else if (routeTemplate.IndexOf("values") != -1)
                {
                    return new HttpControllerDescriptor(
                        _config, "Values",
                        typeof(WebApplication4.Controllers.ValuesController));
                }
                return base.SelectController(request);
            }
        }
