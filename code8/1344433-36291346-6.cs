    public class ValidateAssemblyAttribute : ActionFilterAttribute
    {
        public string classNameField = "className";
    
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Get the field through the helper
            string className = filterContext.GetValue<string>(classNameField); 
    
            // User 2 doesn't have access to xpto.dll
            if (Membership.CurrentUserId == 2 && className == "xpto.dll")
                AuthorizationHelpers.NoPermissions(filterContext);
    
            base.OnActionExecuting(filterContext); // Execute base
        }
    }
    
