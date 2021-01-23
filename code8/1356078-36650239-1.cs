    public class BaseController : Controller
    {
        protected new HttpNotFoundResult HttpNotFound(string statusDescription = null)
        {
            return new HttpNotFoundResult(statusDescription);
        }
        protected HttpUnauthorizedResult HttpUnauthorized(string statusDescription = null)
        {
            return new HttpUnauthorizedResult(statusDescription);
        }
        protected class HttpNotFoundResult : HttpStatusCodeResult
        {
            public HttpNotFoundResult() : this(null) { }
            public HttpNotFoundResult(string statusDescription) : base(404, statusDescription) { }
        }
        protected class HttpUnauthorizedResult : HttpStatusCodeResult
        {
            public HttpUnauthorizedResult(string statusDescription) : base(401, statusDescription) { }
        }
        protected class HttpStatusCodeResult : ViewResult
        {
            public int StatusCode { get; private set; }
            public string StatusDescription { get; private set; }
            public HttpStatusCodeResult(int statusCode) : this(statusCode, null) { }
            public HttpStatusCodeResult(int statusCode, string statusDescription)
            {
                StatusCode = statusCode;
                StatusDescription = statusDescription;
            }
            public override void ExecuteResult(ControllerContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }
                context.HttpContext.Response.StatusCode = StatusCode;
                
                if (StatusDescription != null)
                {
                    context.HttpContext.Response.StatusDescription = StatusDescription;
                }
                
                ViewName = "Error";
                ViewBag.Title = context.HttpContext.Response.StatusDescription;
                base.ExecuteResult(context);
            }
        }
    }
