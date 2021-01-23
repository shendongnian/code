    if (Request.Cookies["CookieName"] == null)
    {
        var cookie = new HttpCookie("CookieName");
        cookie.Value = Guid.NewGuid().ToString();
        cookie.Expires = DateTime.Now.AddHours(12);
        cookie.Secure = false;
        Response.Cookies.Add(cookie);
    }
