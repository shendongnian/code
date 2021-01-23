    public void Init(HttpApplication context)
    {
        context.BeginRequest += (object Sender, EventArgs e) =>
        {
            HttpContext httpContext = HttpContext.Current;
            var httpRequestMessage = new HttpRequestMessage(
                new HttpMethod(httpContext.Request.HttpMethod),
                httpContext.Request.Url);
            IHttpRouteData httpRouteData = 
                GlobalConfiguration.Configuration.Routes.GetRouteData(httpRequestMessage);
            if (httpRouteData != null) //enough if WebApiConfig.Register is empty
                return;
    
            string currentUrl = httpContext.Request.Url.LocalPath.ToLower();
            if (currentUrl.StartsWith("/api/endpoint0") ||
                currentUrl.StartsWith("/api/endpoint1") ||
                currentUrl.StartsWith("/api/endpoint2"))
            {
                httpContext.RewritePath("/api/resource.ashx");
            }
        };
    }
