    void RegisterRoutes(RouteCollection routes)
    {
        var settings = new FriendlyUrlSettings();
        settings.AutoRedirectMode = RedirectMode.Permanent;
        routes.EnableFriendlyUrls(settings);
        /* ... additional routes */
        routes.MapPageRoute("","Person/{IDP}", "~/Person.aspx");
    }
