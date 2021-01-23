    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.Cache.SetNoStore();
        string userid = "";
        string ids = "";
        try
        {
            string userid = context.Request.QueryString["userid"];
            string ids = context.Request.QueryString["ids"];
            //then do your things
        }
        catch (Exception)
        {
            throw;
        }
    }
