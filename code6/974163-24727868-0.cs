    public class ElmahErrorFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            // Long only handled exceptions, because all other will be caught by ELMAH anyway.
            if (filterContext.ExceptionHandled)
                ErrorSignal.FromCurrentContext().Raise(filterContext.Exception);
        }
    }
