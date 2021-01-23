    string host = HttpContext.Current.Request.Url.Host
    switch (host.ToLower())
    {
        case "www.domain.com":
            HttpContext.Current.Response.Redirect("~/Site1");
            break;
        case "www2.domain.com":
            HttpContext.Current.Response.Redirect("~/Site2");
            break;
        default:
            HttpContext.Current.Response.StatusCode = 500;
    }
