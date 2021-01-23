    protected void Application_Error()
    {
        var lastError = Server.GetLastError();
        if (lastError is ArgumentException || lastError is HttpRequestValidationException)
        {
            Server.ClearError();
            Response.StatusCode = (int) HttpStatusCode.BadRequest;
        }
    }
