    protected override IHttpHandler GetHttpHandler(RequestContext Context)
    {
        if (  Context.HttpContext.Request.Url.DnsSafeHost.ToLower().Contains("abc"))
        {
            Context.RouteData.Values["controller"] = "LandingPage";
            Context.RouteData.Values["action"] = "Index"; 
            Context.RouteData.Values["id"] = "abc";
        }
        return base.GetHttpHandler(Context);
    }
