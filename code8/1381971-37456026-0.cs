    if (c.Request.Environment.ContainsKey("Content-Length"))
    {
        c.Response.ContentLength = Convert.ToInt64(c.Request.Environment["Content-Length"]);
        c.Response.ContentType = "application/json; charset=utf-8";
        c.Response.StatusCode = (int)HttpStatusCode.Unauthorized;  
    }  
