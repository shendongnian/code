        foreach (string key in Request.Cookies.AllKeys)
        {
           HttpCookie c = Request.Cookies(key);
           c.Expires = Now.AddMonths(-1);
           Response.AppendCookie(c);
        }
