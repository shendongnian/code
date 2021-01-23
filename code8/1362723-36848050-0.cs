    using System.Web.Mvc;
    using System.Security.Claims;
    
    namespace MyApp.Filters
    {
        public class CustomAttribute : AuthorizeAttribute
        {
            private List<string> adminControllers;
    
            public CustomAttribute()
            {
                this.adminControllers = new List<string>();
    
                //This would be a DB call
                this.adminControllers.Add("MyApp.Controllers.AccountController");
                this.adminControllers.Add("MyApp.Controllers.AdministrationController");
            }
    
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                base.OnAuthorization(filterContext);
    
                //Get the roles for the current user
                var identity = (ClaimsIdentity)filterContext.HttpContext.User.Identity;
                var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role)
                            .Select(c => c.Value).ToList();
    
                //Check if current user has the Admin role
                if (roles.Contains("Admin"))
                {
                    //Check if Admin role has access to current controller
                    if (this.adminControllers.Contains(filterContext.Controller.ToString()))
                    {
                        filterContext.Result = new RedirectResult("~/Home/Error");
                    }
                }
    
                
            }
        }
    }
