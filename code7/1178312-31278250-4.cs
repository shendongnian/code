    protected void ChangeLanguage(object sender, CommandEventArgs e)
    {
        var myLang = new HttpCookie("myLang");
        myLang.Value = e.CommandArgument.ToString();
        myLang.Expires = DateTime.Now.AddYears(1);
        Response.Cookies.Add(myLang);
        Response.Redirect(Request.RawUrl);
    }
