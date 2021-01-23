    public class PreventDirectCallAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.RawUrl.Contains(filterContext.ActionDescriptor.ActionName))
            {
                throw new HttpException(404, "HTTP/1.1 404 Not Found");
            }
            base.OnActionExecuting(filterContext);
        }
    }
