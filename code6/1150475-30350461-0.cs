    protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
    {
        if (!HttpContext.Current.Response.Headers.AllKeys.Contains("SavedFilters"))
            HttpContext.Current.Response.Headers.Add("SavedFilters", "/Orders/Index"); //Standard Value
        Response.Headers.Remove("Server");
        Response.Headers.Remove("X-AspNet-Version");
        Response.Headers.Remove("X-AspNetMvc-Version");
    }
