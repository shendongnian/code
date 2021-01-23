    if (Request.Cookies.AllKeys.Contains("Ortund"))
    {
         HttpCookie cookie = Request.Cookies["Ortund"];
         cookie.Expires = DateTime.Now.AddMonths(-1);
         Response.SetCookie(cookie);
    }
