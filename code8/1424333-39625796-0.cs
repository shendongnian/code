    public class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool basicValidated = false;
            var req = filterContext.HttpContext.Request;
            var auth = req.Headers["Authorization"];
            if (!string.IsNullOrEmpty(auth))
            {
                var cred = System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(auth.Substring(6))).Split(':');
                var userName = cred[0];
                var pass = cred[1];
                var membership = new AccountMembershipService();
                basicValidated = membership.ValidateUser(userName, pass);
                if (!basicValidated)
                {
                    base.OnAuthorization(filterContext);
                }
                else
                {
                    var roles = System.Web.Security.Roles.GetRolesForUser(userName);
                    IPrincipal principal = new GenericPrincipal(
                        new GenericIdentity(userName),roles);
                    Thread.CurrentPrincipal = principal;
                    System.Web.HttpContext.Current.User = principal;
                }
            } else
            {
                base.OnAuthorization(filterContext);
            }
            
        }
    }
