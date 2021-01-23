    protected void Application_Error(Object sender, EventArgs e)
    {
        // Log error to the Event Log
        Exception myError = null;
        if (HttpContext.Current.Server.GetLastError() != null)
        {
            var r = new CustomWebErrorEvent("error", null, 120, HttpContext.Current.Server.GetLastError());
        }
    }
