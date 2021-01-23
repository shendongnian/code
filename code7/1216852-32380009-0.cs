    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {
       HttpContext.Current.User = new GenericPrincipal(customIdentity, null);
    }
   
