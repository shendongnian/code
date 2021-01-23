    private static void RedirectToProvider(HttpContext context, IAuthenticationManager authManager, string providerName)
        {
            var loginProviders = authManager.GetExternalAuthenticationTypes();
    
            var LoginProvider = loginProviders.Single(x => x.Caption == providerName);
    
            var properties = new AuthenticationProperties()
            {
                RedirectUri = String.Format("{0}&{1}=true", context.Request.Url, CallBackKey)
            };
    
            //string[] authTypes = { LoginProvider.AuthenticationType, DefaultAuthenticationTypes.ExternalCookie };
            authManager.Challenge(properties, LoginProvider.AuthenticationType);
    
            //without this it redirect to forms login page
            context.Response.SuppressFormsAuthenticationRedirect = true;
        }
