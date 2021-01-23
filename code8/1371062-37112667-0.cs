    protected string Identifier
    {
        get
        {
            HttpCookie cookie = Request.Cookies[IDENTIFIER_COOKIE];
            if (!cookie)
            {
                cookie = new HttpCookie(IDENTIFIER_COOKIE);
                cookie.Value = Guid.NewGuid().ToString();
            }Cookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Set(cookie);
            return cookie.Value
        }
    }
