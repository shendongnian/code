     UserPrincipal adUser = null;
            using (HostingEnvironment.Impersonate())
            {
                var userContext = System.Web.HttpContext.Current.User.Identity;
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, ConfigurationManager.AppSettings["AllowedDomain"], null,
                    ContextOptions.Negotiate | ContextOptions.SecureSocketLayer);
                adUser = UserPrincipal.FindByIdentity(ctx, userContext.Name);
            }
    // and work with 'adUser' from here on in my controllers...
