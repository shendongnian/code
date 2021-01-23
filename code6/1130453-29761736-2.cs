    FormsAuthentication.SignOut();
    Session.Abandon();
    
    // invalidate authentication cookie
    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
    cookie.Expires = DateTime.Now.AddYears(-1);
    Response.Cookies.Add(cookie);
