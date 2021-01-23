    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,
        Inherited = true, AllowMultiple = false)]
    public class YourAuthorizationFilterAttribute :
        FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            if (httpContext.Request.Cookies["AuthID"].Values["AuthID"] ==
                httpContext.Session["AuthID"].ToString())
                // Let the action get executed
                return;
    
            // Otherwise redirect
            filterContext.Result = new RedirectResult(
                filterContext.Controller.Url("Index", "Home"));
        }
    }
---
    [YourAuthorizationFilter]
    public ActionResult Index()
    {
        // main code here
    }
