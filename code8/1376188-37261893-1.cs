    protected void Application_Error(object sender, EventArgs e)
    {
        // Get the exception object.
        Exception exception = Server.GetLastError();
        // Handle Exception
        // Call Server.ClearError() if the exception is properly handled
    }
