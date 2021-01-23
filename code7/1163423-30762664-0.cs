    public static class UrlHelperExtensions
    {        
        private static IHttpContextAccessor HttpContextAccessor;
    	public static void Configure(IHttpContextAccessor httpContextAccessor)
        {			
            HttpContextAccessor = httpContextAccessor;	
        }
    
        public static string AbsoluteAction(
            this UrlHelper url,
            string actionName, 
            string controllerName, 
            object routeValues = null)
        {
            string scheme = HttpContextAccessor.HttpContext.Request.Scheme;
            return url.Action(actionName, controllerName, routeValues, scheme);
        }
    
        ....
    }
