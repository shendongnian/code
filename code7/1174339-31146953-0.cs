    public static string ApplicationStartTimings { get; private set; }
    protected void Application_Start(object sender, EventArgs e)
    {
        // init MiniProfiler.Settings here
        // ...
        var prof = new MiniProfiler("Application_Start");
        using (prof.Step("Register routes"))
        {
            RegisterRoutes(RouteTable.Routes);
        }
        // ... more config and steps
        try
        {
            ApplicationStartTimings = prof.Render().ToString();
        }
        catch { }
    }
