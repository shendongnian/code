    [Filters.AllowAnonymousActionFilter]
    [HttpPost]
    public JsonResult Login(string username, string password, bool rememberMe = false)
    {
        LoginService service = new LoginService();
        Contracts.IUser user = service.Login(username, password);
        string userData = Serialize(user); // Up to you to write this Serialize method
        var ticket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddHours(24), rememberMe, userData);
        string encryptedTicket = FormsAuthentication.Encrypt(ticket);
        Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket));
    
        return new SuccessResponseMessage().AsJsonNetResult();
    }
