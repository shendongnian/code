    private void Application_Error(object sender, EventArgs e)
    {
        Exception ex = this.Server.GetLastError();   
        // ...
    	HttpApplication application = (HttpApplication)sender;
    	HttpContext context = application.Context;
        context.Session["LastError"] = ex;
        Response.Redirect("~/Error.aspx");
    }
