    public class RemappingModule: IHttpModule
    {
        public void Dispose() { }
    
        public void Init(HttpApplication context)
        {
            context.PostResolveRequestCache += (src, args) =>
            {
                HttpContext httpContext = HttpContext.Current;
                string currentUrl = httpContext.Request.FilePath;
                if (!string.IsNullOrEmpty(httpContext.Request.QueryString.ToString()))
                    currentUrl += "?" + httpContext.Request.QueryString;
                //checking if url was rewritten
                if (httpContext.Request.RawUrl != currentUrl) 
                {
                    //getting original url
                    string url = string.Format("{0}://{1}{2}",
                        httpContext.Request.Url.Scheme,
                        httpContext.Request.Url.Authority,
                        httpContext.Request.RawUrl);
                    var httpRequestMessage = new HttpRequestMessage(
                        new HttpMethod(httpContext.Request.HttpMethod), url);
                    //checking if Web API routing system can find route for specified url
                    IHttpRouteData httpRouteData = 
                        GlobalConfiguration.Configuration.Routes.GetRouteData(httpRequestMessage);
                    if (httpRouteData != null)
                    {
                        //to be honest, I found out by experiments, that 
                        //context route data should be filled that way
                        var routeData = httpContext.Request.RequestContext.RouteData;
                        foreach (var value in httpRouteData.Values)
                            routeData.Values.Add(value.Key, value.Value);
                        //rewriting back url
                        httpContext.RewritePath(httpContext.Request.RawUrl);
                        //remapping to Web API handler
                        httpContext.RemapHandler(
                            new HttpControllerHandler(httpContext.Request.RequestContext.RouteData));
                    }
                }
            };
        }
    }
