    namespace WebApplication3.Areas.Users
    {
        public class UsersAreaRegistration : AreaRegistration 
        {
            public override string AreaName 
            {
                get 
                {
                    return "Users";
                }
            }
    
            public override void RegisterArea(AreaRegistrationContext context) 
            {
                context.MapRoute(
                    "User_Choose",
                    "Users/{controller}/{action}/{userId}/{locationId}",
                        new { controller = "Reward", action = "Choose", userId = UrlParameter.Optional }
                );
            }
        }
    }
