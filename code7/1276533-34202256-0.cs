    public class CustomExceptionFilter : IExceptionFilter
    {    
            public void OnException(ExceptionContext filterContext)
            {
                   
                if (filterContext.ExceptionHandled)
                    return;    
                //Do yout logic here
            }
    }
