    protected void Application_Error()
    {
        var apiException = Server.GetLastError() as ApiException;
        if (apiException != null)
        {
            Response.Clear();
            Server.ClearError();
            Response.StatusCode = 400;
            Context.Response.Write("YOUR JSON HERE");
        }
    }
