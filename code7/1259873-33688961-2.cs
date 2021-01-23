            public class AllowCrossSiteAttribute : ActionFilterAttribute
            {
                public override void OnActionExecuting(ActionExecutingContext filterContext)
                {
                    switch (filterContext.RequestContext.HttpContext.Request.Headers["Origin"])
                    {
                        case "https://myotherwebsite1.com":
                            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", filterContext.RequestContext.HttpContext.Request.Headers["Origin"]);
                            break;
                        case "https://myotherwebsite2.com":
                            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", filterContext.RequestContext.HttpContext.Request.Headers["Origin"]);
                            break;
                        default:
                            filterContext.Result = new EmptyResult();
                            break;
                    }
    
                    base.OnActionExecuting(filterContext);
                }
            }
