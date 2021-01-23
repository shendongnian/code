    public class AllowIframeFromUriAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //...
            filterContext.HttpContext.Response.Headers.Remove("X-Frame-Options");
            base.OnResultExecuted(filterContext);
        }
    }
