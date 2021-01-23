    namespace StockManagment.Areas.Admin
    {
        public class AdminAreaRegistration : AreaRegistration
        {
            public override string AreaName
            {
                get
                {
                    return "Admin";
                }
            }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}", // your current url= /Admin/Home/Categories -- which means id = Categories
                new { action = "Index", id = UrlParameter.Optional },
                new [] {"StockManagment.Areas.Admin.Controllers"}
            );
        }
    }}
