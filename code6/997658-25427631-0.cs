    public class MyErrorHandlerAttribute : FilterAttribute, IExceptionFilter
        {
            public void OnException(ExceptionContext filterContext)
            {
                filterContext.HttpContext.Response.StatusCode = 11001;
                filterContext.ExceptionHandled = true;
                filterContext.Result = new JsonResult
    
                {
                    Data = new { success = false, error = filterContext.Exception.ToString() },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }
