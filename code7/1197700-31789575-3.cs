    if(HttpContext.Current.Request.IsAuthenticated)
    {
        //continue normal code here
    }
    else
    {
        //probably should return an HTTP 401 Unauthorized code
        Response.StatusCode = 401;
        Response.End();
    }
