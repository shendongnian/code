    public ActionResult SetCulture(string culture, string url)
    {
        // Validate input
        culture = CultureHelper.GetImplementedCulture(culture);
        // Save culture in a cookie
        HttpCookie cookie = Request.Cookies["_culture"];
        if (cookie != null)
            cookie.Value = culture;   // update cookie value
        else
        {
            cookie = new HttpCookie("_culture");
            cookie.Value = culture;
            cookie.Expires = DateTime.Now.AddYears(1);
        }
        Response.Cookies.Add(cookie);
        return Redirect(url);
    }
