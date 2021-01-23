    private static HttpCookie GetCookie(HttpResponseBase resp)
    {
        HttpCookie cookie = resp.Cookies["HolidayAdmin"];
        if (cookie == null)
        {
            cookie = new HttpCookie("HolidayAdmin");
            resp.Cookies.Add(cookie);
        }
        return cookie;
    }
