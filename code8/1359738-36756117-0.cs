    public class ContentLengthFilter : ActionFilterAttribute
    {
        public ContentLengthFilter(int maxContentLength)
        {
            MaxContentLength = maxContentLength;
        }
        public int MaxContentLength { get; private set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.ContentLength > MaxContentLength)
                throw new InvalidOperationException();
            base.OnActionExecuting(filterContext);
        }
    }
