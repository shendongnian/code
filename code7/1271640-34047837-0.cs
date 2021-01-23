    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private string[] _roles;
        
        public CustomAuthorizeAttribute(params string[] roles)
        {
            _roles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = httpContext.User;
            var isAuthorized = false;
            
            // check in the database to see if the user 
            // is in one of the Roles in _roles and therefore authorized...
            if(/* some code to check if the user is authorized */)
            {
               isAuthorized = true;
            }
            return isAuthorized;
        }
        
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }
    }
