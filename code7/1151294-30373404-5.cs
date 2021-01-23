    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions {
                        // YOUR LOGIN PATH
                        LoginPath = new PathString("/Account/Login")
                }
            );
        }
    }
