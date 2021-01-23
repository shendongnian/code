    public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{*angular}",
                new { action = "Index",
                new [] {"StockManagment.Areas.Admin.Controllers"}
            );
        }
