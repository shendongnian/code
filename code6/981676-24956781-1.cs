    if (page != null && Request.Browser.Cookies) {
        Response.Cookies.Remove("page");
        var pages = new HttpCookie("page") { Value = page.ToString(), Expires = DateTime.Now.AddDays(7) };
        Response.Cookies.Add(pages);
    }
