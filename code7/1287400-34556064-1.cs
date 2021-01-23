    public class DenyAttribute : AuthorizeAttribute
    {
    
        protected override bool AuthorizeCore(HttpContextBase httpContext) {
            if (httpContext == null) {
                throw new ArgumentNullException("httpContext");
            }
    
            IPrincipal user = httpContext.User;
            if (!user.Identity.IsAuthenticated) {
                return false;
            }
    
            if (Users.Length > 0 && Users.Split(',').Any( u => string.Compare( u.Trim(), user.Identity.Name, StringComparer.OrdinalIgnoreCase))) {
                return false;
            }
    
            if (Roles.Length > 0 && Roles.Split(',').Any( u => user.IsInRole(u.Trim()))) {
                return false;
            }
    
            return true;
        }
