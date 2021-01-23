    public override void RegisterArea(AreaRegistrationContext context) 
    {
        context.MapRoute(
            "Admin_default",
            "Admin/{controller}/{action}/{id}",
            defaults: new { action = "Index", controller = "Admin", id = UrlParameter.Optional },
            namespaces: new[] { "BlocqueStore_Web.Areas.Admin.Controllers" }
        );
    }
