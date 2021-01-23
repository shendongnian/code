    public class MyCookieAuthenticationEvents : CookieAuthenticationEvents
    {
        public override Task RedirectToLogin(CookieRedirectContext context)
        {
            context.RedirectUri = <PUT LOGIC HERE TO REPLACE YOUR REDIRECT URI>
            return base.RedirectToLogin(context);
        }
    }
