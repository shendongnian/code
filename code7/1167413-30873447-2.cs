    public class SetAuthFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var key = CreateKey(filterContext);
            var isCached = HttpRuntime.Cache.Get(key);
            if (isCached != null) return;
            HttpRuntime.Cache.Insert(key, true);
            // Heavy auth logic here
        }
        private string CreateKey(AuthorizationContext context)
        {
            // Or create some other unique key that allows you to identify 
            // the same request
            return
                context.RequestContext.HttpContext.User.Identity.Name + "|" +
                context.RequestContext.HttpContext.Request.Url.AbsoluteUri;
        }
    }
