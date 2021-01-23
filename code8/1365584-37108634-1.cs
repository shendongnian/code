    public partial class Startup {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
            // Basic for site guest
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                LogoutPath = new PathString("/Account/Logout"),
                Provider = new CookieAuthenticationProvider {
                    OnApplyRedirect = RedirectIfAdmin,
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
       }
