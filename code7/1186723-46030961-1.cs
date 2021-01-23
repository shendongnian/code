    protected void Application_BeginRequest()
    {
    
        if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
        {
            //These headers are handling the "pre-flight" OPTIONS call sent by the browser
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://staging.example.com:8044");
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Accepts, Content-Type, Origin, X-My-Header");
            HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "60");
            HttpContext.Current.Response.End();
        }
     
    }
