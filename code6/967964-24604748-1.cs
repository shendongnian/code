    void Application_BeginRequest(object sender, EventArgs e)
    {
        var app = (HttpApplication)sender;
        if (app.Context.Request.Url.LocalPath.EndsWith("/"))
        {
        app.Context.RewritePath(
                 string.Concat(app.Context.Request.Url.LocalPath, "default.aspx"));
        }
    }
