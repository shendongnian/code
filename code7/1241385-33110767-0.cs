    void ErrorLog_Filtering(object sender, ExceptionFilterEventArgs args)
    {
        var httpContext = args.Context as HttpContext;
        if (httpContext != null && args.Exception is TimeoutException)
        {
            var error = new Error(args.Exception, httpContext);
            error.Message = "DB Timeout - SP name";
            ErrorLog.GetDefault(httpContext).Log(error);
            args.Dismiss();
        }
    }
