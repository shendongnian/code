    public override void RegisterArea(AreaRegistrationContext context)
    {
                context.MapRoute(
                    "Public_default",
                    "Public/{controller}/{action}/{filename}",
                    new { action = "Index", controller = "Documents" }
                );
    }
