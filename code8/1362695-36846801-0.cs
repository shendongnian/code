    public class PolicyAreaRegistration : AreaRegistration
    {
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Policy_Tricky",
                "Policy/{action}/{id}",
                new { action = "Index", controller = "Policy", id = UrlParameter.Optional },
               new string[] { "YourProjectName.Areas.Policy.Controllers" }
            );
            context.MapRoute(
                "Policy_default",
                "Policy/{controller}/{action}/{id}",
                new { action = "Index", controller = "Home", id = UrlParameter.Optional },
               new string[] { "YourProjectName.Areas.Policy.Controllers" }
               //Providing namespace while defining route to prevent conflict 
            );
        }
    }
