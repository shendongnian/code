    public ActionResult SomeAction() 
    {
        //http://stackoverflow.com/a/31918218
        var app = HttpContext.GetOwinContext().Get<AppBuilderProvider>("AspNet.Identity.Owin:" + typeof(AppBuilderProvider).AssemblyQualifiedName).Get();
		var protector = Microsoft.Owin.Security.DataProtection.AppBuilderExtensions.CreateDataProtector(app, typeof(Microsoft.Owin.Security.OAuth.OAuthAuthorizationServerMiddleware).Namespace, "Access_Token", "v1");
		var tdf = new Microsoft.Owin.Security.DataHandler.TicketDataFormat(protector);
		var ticket = new AuthenticationTicket(ci, null);
		var accessToken = tdf.Protect(ticket);
        //you now have an access token that can be used.
    }
