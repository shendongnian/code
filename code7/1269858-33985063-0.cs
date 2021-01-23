    protected void Application_BeginRequest()
    {
        if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
        {
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST, PUT, DELETE, GET, OPTIONS");
                HttpContext.Current.Response.End();
            }
        }
    }
