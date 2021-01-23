    protected void Application_Error()
    {
        var context = HttpContext.Current;
        var exception = context.Server.GetLastError();
        try
        {
            //Operations you need to perform
        }
        catch (HttpRequestValidationException)
        {
          //Output Error
        }
    }
