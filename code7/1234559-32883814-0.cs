    public void ChangeCulture(string lang)
    {
        Response.Cookies.Remove("Language");
        HttpCookie languageCookie = System.Web.HttpContext.Current.Request.Cookies["Language"];
        if (languageCookie == null) languageCookie = new HttpCookie("Language");
        languageCookie.Value = lang;
        languageCookie.Expires = DateTime.Now.AddDays(10);
        Response.SetCookie(languageCookie);
        Response.Redirect(Request.UrlReferrer.ToString());
    }
