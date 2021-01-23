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
          ModelState.AddModelError("ErrorName", "This is where you put your error message");
        }
    }
