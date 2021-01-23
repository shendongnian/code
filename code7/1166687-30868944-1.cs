    public JekController() : base()
    {
        ...
        if(!System.Web.HttpContext.Current.Request.IsAuthenticated)
        {
            LoginService.SignInFromAuthCookie(Request.Cookies[FormsAuthentication.FormsCookieName]);
        }
    }
