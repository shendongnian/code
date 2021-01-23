    public override string AreaName => "Profile";
    public override void RegisterArea(AreaRegistrationContext context)
    {
        context.MapRoute(
            "Profile_media",
            "{ProfileName}/Media/{id}",
            new
            {
                area = "Profile",
                controller = "Media",
                action = "Index"
            },
            new[] { "MySite.Areas.Profile.Controllers" });
        context.MapRoute(
            "Profile_default",
            "{ProfileName}/{controller}/{action}/{id}",
            new
            {
                area = "Profile",
                controller = "Home",
                action = "Index",
                id = UrlParameter.Optional
            },
            new[] { "MySite.Areas.Profile.Controllers" });
    }
