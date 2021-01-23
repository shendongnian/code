    protected void Session_Start(object sender, EventArgs e)
    {
        Response.Cookies.Add(new HttpCookie("SessionCookie", "some_value"));
    }
    public override string GetOutputCacheProviderName(HttpContext context)
    {
        bool isInSession = true; // Determine here.
        if (context.Request.Cookies["SessionCookie"] != null)
        {
            // Use your CustomProvider
        }
        if (isInSession)
        {
            return "CustomProvider";
        }
        // Or by page:
        if (context.Request.Path.EndsWith("MyPage.aspx"))
        {
            return "SomeOtherProvider";
        }
        return base.GetOutputCacheProviderName(context);
    }
