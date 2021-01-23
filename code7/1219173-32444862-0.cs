    protected void Application_Error(object sender, EventArgs e)
    {
        Exception exception = Server.GetLastError();
        // Log the exception.
        logger.Error(exception);
        Response.Clear();
        Context.Response.Redirect("~/"); // it will redirect to just main page of your site. Replace this line to redirect whatever you need.
    }
