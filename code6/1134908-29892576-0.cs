    public class AndAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            try
            {
                if (Roles != null && Roles.Any())
                {
					foreach(var role in Roles){
					if(!httpContext.User.IsInRole(role))
						return false;
					}
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
