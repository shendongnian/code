    private bool Alerted()
    {
        if (Request.Cookies["alerted"] != null)
             return Server.HtmlEncode(Request.Cookies["alerted"].Value) == "true";
        else
        {
           Response.Cookies["alerted"].Value = "true";
           Response.Cookies["alerted"].Expires = DateTime.Now.AddDays(10);
           return false;
        }
    }
