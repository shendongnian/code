    protected void Application_Error(object sender, EventArgs e)
    {
        Exception exc = Server.GetLastError();
    
        if (exc.GetType() == typeof(HttpException))
        {
            Server.ClearError();
    
            var http_ex = exc as HttpException;
    
            var error_code = http_ex.GetHttpCode();
    
            if (error_code == 404)
            {
                Response.Redirect("~/404.aspx", true);
            }
            if (error_code == 500)
            {
                Response.Redirect("~/500.aspx", true);
            }
        }
    }
