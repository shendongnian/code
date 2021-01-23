    protected void Application_EndRequest()
    {
        /*
        if(HttpContext.Current.Response.StatusCode == 404)
            Debug.WriteLine("404 something something")
        if(HttpContext.Current.Response.StatusCode == 500)
            Debug.WriteLine("500 something something")
        if(HttpContext.Current.Response.StatusCode == 200)
            Debug.WriteLine("200 something something")
        */
        Debug.WriteLine($"{context.Response.StatusCode} - {request.Url.PathAndQuery}");
    }
