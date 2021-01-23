    public class MyCustomAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            string vUser = httpContext.Session["user_name"].ToString();
            if (vUser != "")
            {
                return true; // yay user found
            }
            return false; // user not found, this will cause the redirection to kick in
    }
