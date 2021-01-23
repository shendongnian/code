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
                // Handle accordingly
            }
            base.OnActionExecuting(filterContext);
        }
    }
