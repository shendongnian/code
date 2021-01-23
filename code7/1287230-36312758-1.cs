    public class HangFireAuthorizationFilter:IAuthorizationFilter
        {
            public bool Authorize(IDictionary<string, object> owinEnvironment)
            {
                // In case you need an OWIN context, use the next line.
                // `OwinContext` class is defined in the `Microsoft.Owin` package.
                var context = new OwinContext(owinEnvironment);
    
                return context.Authentication.User.Identity.IsAuthenticated &&
                       context.Authentication.User.IsInRole("xyz");
    
            }
    
        }
