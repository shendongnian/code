    public class YourAllowAnonymousAttribute : ActionFilterAttribute
    {
        // Nothing to implement.
    }
---
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,
        Inherited = true, AllowMultiple = false)]
    public class YourAuthorizationFilterAttribute :
        FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(
                    typeof(YourAllowAnonymousAttribute), inherit) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(
                    typeof(YourAllowAnonymousAttribute), true))
                return;
            ...
