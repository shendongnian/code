    public virtual void OnException(ExceptionContext filterContext)
    {
        if (filterContext.Exception is HttpException)
        {
            var statusCode = ((HttpException)filterContext.Exception).GetHttpCode();
            if (statusCode >= 500 && statusCode < 600)
            {
                filterContext.RequestContext.HttpContext.Response.AddHeader("Custom-Key", "error");
                filterContext.ExceptionHandled = true;
            }
        }
    }
