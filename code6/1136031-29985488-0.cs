    //this line is NOT ENOUGH for "remember me" to work!!!
    FormsAuthentication.SetAuthCookie(userName, true); //DOESN'T WORK!
    //###########
    //you have to save the "remember me" info inside the auth-ticket as well
    //like this:
    DateTime expires = DateTime.Now.AddDays(20); //remember for 20 days
    //create the auth ticket
    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
    	userName,
    	DateTime.Now,
    	expires, // value of time out property
    	true, // Value of IsPersistent property!!!
    	String.Empty,
    	FormsAuthentication.FormsCookiePath);
    
    //now encrypt the auth-ticket
    string encryptedTicket = FormsAuthentication.Encrypt(ticket);
    
    //now save the ticket to a cookie
    HttpCookie authCookie = new HttpCookie(
    			FormsAuthentication.FormsCookieName,
    			encryptedTicket);
    authCookie.Expires = expires;
    
    //feed the cookie to the browser
    HttpContext.Current.Response.Cookies.Add(authCookie);
