    var myCookies = Request.Cookies.AllKeys;
    foreach (var cookieName in myCookies)
    {
        var cookie = Request.Cookies[cookieName];
        if (cookie == null) continue;
        cookie.Value = "written " + DateTime.Now;
        cookie.Expires = DateTime.Now.AddYears(-1);
        Response.Cookies.Add(cookie);
    }
