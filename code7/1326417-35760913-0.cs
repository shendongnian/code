    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        var result =WebUtility.UrlDecode(new StreamReader(context.Request.InputStream).ReadToEnd());
    }
