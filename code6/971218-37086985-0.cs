    void RegisterRoutes(RouteCollection routes)
    {
         /* ... additional routes */
        routes.MapPageRoute("","Person/{IDP}", "~/Person.aspx");
    
        var settings = new FriendlyUrlSettings();
        settings.AutoRedirectMode = RedirectMode.Permanent;
        routes.EnableFriendlyUrls(settings);
    
    }
