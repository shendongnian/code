    public class SetAuthFilter : IAuthorizationFilter
    {
        private static Cache _cache = new Cache();
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var key = CreateKey(filterContext);
            var isCached = _cache.Get(key);
            if (isCached != null) return;
            _cache.Add(
                key, true, null, 
                new DateTime().AddDays(1), new TimeSpan(1, 0, 0, 0), 
                CacheItemPriority.High, null);
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
