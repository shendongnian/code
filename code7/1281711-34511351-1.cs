    public ActionResult LogoutCallback()
    {
    	HttpCookie cookie = new HttpCookie("SecureCookieName");
    	cookie.HttpOnly = true;
    	cookie.Expires = new DateTime(1999, 10, 12);
    	Response.Cookies.Remove("SecureCookieName");
    	Response.Cookies.Add(cookie);
    
    	SetPasswordResetHint();
    
    	return RedirectToAction("Index");
    }
