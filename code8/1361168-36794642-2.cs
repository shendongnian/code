    public class CustomAuthorize : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Use the context to access the user 
            var user = filterContext.HttpContext.User;
            if(user != null)
            {
                // Check your role and redirect accordingly here
                var roles = Roles.GetRolesForUser(user.Identity.Name);
                // Grab the first role (example)
                var role = roles.FirstOrDefault();
                // Based on the users role, do something
                switch(role)
                {
                     case "Administrator":
                           // Handle your redirect here
                           filterContext.Result = new RedirectToRouteResult("Admin", routeValues);
                     break;
                     default:
                           // Do nothing, allow to pass through as usual
                     break;
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
