    if(!Request.Cookies.AllKeys.Contains("Ortund"))
    {
         HttpCookie cookie = new HttpCookie("Ortund");
         // insert cookie values
         cookie.Expires = DateTime.Now.AddMonths(1);
         Response.Cookies.Add(cookie);
    }  
