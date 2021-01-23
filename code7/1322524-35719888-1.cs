    void context_BeginRequest(object sender, EventArgs e)
    {
        string encodedQueryString = String.Empty;
        if (HttpContext.Current.Request.QueryString.Count > 0 && HttpContext.Current.Request.QueryString["q"] != null)
        {
            string encodedQueryString = HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.QueryString["q"].ToString());
            HttpContext.Current.Items("qs_d") = HttpContext.Current.Server.UrlDecode(WebFunction.Base64Decode(encodedQueryString));
        }
    }
