    public class YourAuthorizationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var roles = this.Roles;            
            //your things   
            base.OnAuthorization(filterContext);
        }    
    }
