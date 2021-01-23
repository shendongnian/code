    using System.Web.Mvc;
    // not
    // using System.Web.Http.Filters;
    
    public class MyAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string rawRequest;
            using (var stream = new StreamReader(filterContext.HttpContext.Request.InputStream))
            {
                string rawRequest=stream.ReadToEnd();
            }
        }
    }
