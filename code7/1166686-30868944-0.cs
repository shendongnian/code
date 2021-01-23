    public JekController() : base()
    {
        LoginService = new LoginService();
        TimeSheetService = new TimeSheetService();
        if(!System.Web.HttpContext.Current.Request.IsAuthenticated)
        {
            LoginService.SignInFromAuthCookie(Request.Cookies[FormsAuthentication.FormsCookieName]);
        }
    }
