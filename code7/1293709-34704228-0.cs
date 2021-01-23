    public class CustomExceptionHandlerAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
        	if(filterContext.ExceptionHandled)
		    	return;
		    ConfigureResponse();
		    return new RouteValueDictionary
            {
                {"controller", Test},
                {"action", Index},
                {"exceptionMessage", filterContext.Exception.Message}
            };
            // log your error
            base.OnException(filterContext);
        }
        private void ConfigureResponse(ExceptionContext filterContext)
        {
        	filterContext.ExceptionHandled = true;
		    filterContext.HttpContext.Response.Clear();
		    filterContext.HttpContext.Response.StatusCode = 500;
		    
		    filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }        
    }
