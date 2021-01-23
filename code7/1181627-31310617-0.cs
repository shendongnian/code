    protected virtual void Application_BeginRequest(object sender, EventArgs e)
    {
        var url = Request.Url.AbsoluteUri;
        var path = Request.Url.AbsolutePath;
        var host = Request.Url.Host;
        // your magic here goes here
    }
