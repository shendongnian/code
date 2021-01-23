    using System.Web.Mvc;
    
    namespace MyApplication
    {
        public class NoIframeAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Headers.Set("X-Frame-Options", "SAMEORIGIN");
            }
        }
    }
