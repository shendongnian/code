    public class HandleHttpRequestValidationExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //base.OnException(filterContext);
    
            if (!(filterContext.Exception is HttpRequestValidationException))
                return;
    
            const string viewName = "~/Views/Shared/Errors/HttpRequestValidationException.cshtml";
    
            var result = new ViewResult
            {
                ViewName = viewName,
                ViewData = { Model = filterContext.Exception.Message }
            };
    
            //result.ViewBag.StatusCode = 200;
    
            filterContext.Result = result;
            filterContext.RouteData.Values["area"] = "";
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 200;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            filterContext.HttpContext.Server.ClearError();
        }
    }
