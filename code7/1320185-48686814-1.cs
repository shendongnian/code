    public ActionResult LogOff()
    {
        AuthenticationManager.Si`enter code here`gnOut(DefaultAuthenticationTypes.ApplicationCookie);
        return RedirectToAction("Login", "Account");
        Response.Cookies.Clear();
        FormsAuthentication.SignOut();
        HttpCookie c = new HttpCookie("Login");
        c.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(c);
        Session.Clear();
    }
    
    
