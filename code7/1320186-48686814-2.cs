    public ActionResult LogOff()
    {
        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        return RedirectToAction("Login", "Account");
        Response.Cookies.Clear();
        FormsAuthentication.SignOut();
        HttpCookie c = new HttpCookie("Login");
        c.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(c);
        Session.Clear();
    }
    
    
