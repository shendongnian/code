    app.UseOpenIdConnectAuthentication(
        new OpenIdConnectAuthenticationOptions
        {
            ClientId = clientId,
            Authority = Authority,
            Notifications = new OpenIdConnectAuthenticationNotifications()
            {
                AuthorizationCodeReceived = (context) =>
               {
                   var code = context.Code;
                   ClientCredential credential = new ClientCredential(clientId, appKey);
                   string tenantID = context.AuthenticationTicket.Identity.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid").Value;
                   string signedInUserID = context.AuthenticationTicket.Identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                   AuthenticationContext authContext = new AuthenticationContext(string.Format("https://login.windows.net/{0}", tenantID), new EFADALTokenCache(signedInUserID));
                   AuthenticationResult result = authContext.AcquireTokenByAuthorizationCode(
                               code, new Uri(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path)), credential, graphResourceID);
                   return Task.FromResult(0);
                },
                ...
        }
