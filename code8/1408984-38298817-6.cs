    protected void Application_Error(Object sender, EventArgs e)
    {
        Exception ex = Server.GetLastError();
        if (ex is ThreadAbortException)
            return; // Redirects may cause this exception..
        Logger.Error(LoggerType.Global, ex, "Exception");
        Response.Redirect("unexpectederror.htm");
    }
