    protected void Application_EndRequest()
    {
        // removing excessive headers. They don't need to see this.
        Response.Headers.Remove("header_name");
    }
