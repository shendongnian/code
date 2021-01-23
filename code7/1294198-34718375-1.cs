    public class CrawlerFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userAgent = context.HttpContext.Request.UserAgent;
            //Do something with the userAgent and/or drop the request
        }
    }
