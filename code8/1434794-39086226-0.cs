    private void Application_EndRequest(object sender,EventArgs e)
    {
        var oldCookie = Request.Cookies["SiteCookie"];
        if (oldCookie != null)
        {
            var newCookie = new HttpCookie("SiteCookie", oldCookie.Value);
            newCookie.Expires = System.DateTime.Now.AddHours(1);
            Response.AppendCookie(newCookie);
        }
    }
