    protected void Application_Error(object sender, EventArgs e)
    {
        HttpContext ctx = HttpContext.Current;
    
        Exception ex = ctx.Server.GetLastError();
    
    	var path = HttpContext.Server.MapPath("~/App_Data");
        ExceptionLog.Create(Ex, path);
    }
