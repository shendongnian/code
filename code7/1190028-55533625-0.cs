    if you are using the FormsAuthentication, you can use this code. It will help you:
    FormsAuthentication.SignOut();
    Session.Clear();
    Session.Abandon();
    Session.RemoveAll();
    // clear authentication cookie
    HttpCookie httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
    httpCookie.Expires = DateTime.Now.AddYears(-1);
    Response.Cookies.Add(httpCookie);
