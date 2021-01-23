    public class RoleAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
            filterContext.Result = new RedirectResult(urlHelper.Action("Index", "Authentication"));
        }
    
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var permission = httpContext.Request.RequestContext.RouteData.GetRequiredString("controller");
            var user = httpContext.User.Identity.IsAuthenticated == true ? ((MyUserIdentity)httpContext.User.Identity) : null;
            
            if (user == null)
                return false;
    
            if (permission.Equals("Home"))
                return true;
    
            int count = 0;
            using (var con = new myAppEntities())
            {
                var permissionid = con.permissions.Where(p => p.PermissionName.Equals(permission)).Single().PermissionId;
                count = con.rolepermissions.Where(rp => rp.PermissionId == permissionid && rp.RoleId == user.RoleId).Count();
            }
    
            if (count > 0)
                return true;
            else
                return false;
        }
    }
