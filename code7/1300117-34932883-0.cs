    public static void RegisterRoutes(RouteCollection routes)
    {
        FriendlyUrlSettings aspxSettings = new FriendlyUrlSettings();
        aspxSettings.AutoRedirectMode = RedirectMode.Off;  // default=Off
        routes.EnableFriendlyUrls(aspxSettings);
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } 
        );
        routes.MapPageRoute("Design-Fancy", "Design/Fancy/{*queryvalues}", "~/Design/Fancy.aspx", true);
        routes.MapPageRoute("Design-Simple", "Design/Simple/{*queryvalues}", "~/Design/Simple.aspx", true);
    } 
