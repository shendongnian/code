    protected void Application_BeginRequest()
    {
      if (FormsAuthentication.RequireSSL && !Request.IsSecureConnection)
      {
        Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"));
      }
    }
