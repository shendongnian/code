    void context_BeginRequest(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.QueryString.Count > 0 && HttpContext.Current.Request.QueryString["q"] != null)
        {
            string encodedPath = HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.Path);
            HttpContext.Current.RewritePath(encodedPath);
        }
    }
