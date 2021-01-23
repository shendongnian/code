        public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Security/Login"),
                CookieSecure = CookieSecureOption.SameAsRequest,
                SlidingExpiration = true,
                CookieName = "Program.Auth",
                ExpireTimeSpan = TimeSpan.FromSeconds(15)/*FromHours(1)*/,
                Provider = new CookieAuthenticationProvider { OnApplyRedirect = CustomRedirect }
            });
            // TODO - Figure out what claims type to base this on.
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Email;
        }
        private static void CustomRedirect(CookieApplyRedirectContext context)
        {
            var redirectUrl = context.Options.LoginPath.ToString();
            if (context.Request.Method == WebRequestMethods.Http.Get)
            {
                var returnUrl = context.Request.Path.ToString();
                if (!string.IsNullOrEmpty(returnUrl) && !returnUrl.Equals("/"))
                    redirectUrl += "?" + context.Options.ReturnUrlParameter + "=" + returnUrl;
            }
            else if (context.Request.Method == WebRequestMethods.Http.Post)
            {
                //TODO: add toastr message showing that the post did not succeed
            }
            context.Response.Redirect(redirectUrl + "?tbn=inactive");
        }
    }
