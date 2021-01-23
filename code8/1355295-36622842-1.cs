    public class Authorization : AuthorizeAttribute
    {
    public string Roles { get; set; }
    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
        if (User != null)
        {
            if (String.IsNullOrEmpty(Roles))
            {
                return true;
            }
            string[] split = Roles.Split(',');
            foreach (UserRole item in User)
            {
                if (split.Contains(item.Role.CodeName))
                {
                    return true;
                }
            }
            return false;
        }
        else
            return false;
    }
    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
        filterContext.Result = new HttpUnauthorizedResult();
    }
    }
 
