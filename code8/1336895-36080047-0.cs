    public static void AddProperFileNameHeadersIfIE(HttpContextBase httpContext, string fileName)
    {
        var browser = httpContext.Request.Browser;
        if (browser != null && browser.Browser.Equals("ie", StringComparison.OrdinalIgnoreCase))
        {
            httpContext.Response.AppendHeader("Content-Disposition", "attachment; filename*=UTF-8''" + HttpUtility.UrlPathEncode(fileName) + "\"");
        }
        else
        {
            httpContext.Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + HttpUtility.UrlPathEncode(fileName) + "\"");
        }
    }
