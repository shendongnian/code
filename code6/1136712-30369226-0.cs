    public class MyFilterAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            // I don't want /elmah routes to execute for this filter.
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            if (string.Equals(controllerName, "Elmah", StringComparison.Ordinal))
            {
                return;
            }
        }
    }
