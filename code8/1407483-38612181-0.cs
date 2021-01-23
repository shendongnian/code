    public class MVCAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MVC";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MVC_default",
                "MVC/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );           
        }
    }
