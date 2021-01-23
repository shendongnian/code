    if you are using the FormsAuthentication, you can use this code. By using this code you can destroy the created cookies by setting the Expire property of HttpCookie. It will help you:
    FormsAuthentication.SignOut();
    Session.Clear();
    Session.Abandon();
    Session.RemoveAll();
    // clear authentication cookie
    HttpCookie httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
    httpCookie.Expires = DateTime.Now.AddYears(-1);
    Response.Cookies.Add(httpCookie);
