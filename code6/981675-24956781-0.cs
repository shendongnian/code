    if (page != null && Request.Browser.Cookies) {
        Response.Cookies.Remove("page");
        var aCookie = new HttpCookie("page") { Expires = DateTime.Now.AddDays(-1) };
        Response.Cookies.Add(aCookie);
    }
