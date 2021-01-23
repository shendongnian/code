    public class CustomExceptionFilter: FilterAttribute,  
    IExceptionFilter   
    {  
        public void OnException(ExceptionContext filterContext)   
        {  
            if (!filterContext.ExceptionHandled)   
            {  
                //log error here 
                Logger.LogException(filterContext.Exception);
                //this will redirect to error page and show use logging is done 
                filterContext.Result = new   
                            RedirectResult("customErrorPage.html");  
                 filterContext.ExceptionHandled = true;  
            }  
        }  
    }
