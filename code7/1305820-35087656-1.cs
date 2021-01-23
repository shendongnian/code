	public partial class Startup
    {
        public void ConfigureAuthentication(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login"),
                Provider = new CookieAuthenticationProvider()
                {
                    OnValidateIdentity = context =>
                    {
                        string userName = context.Identity.Name;
                        User user = userRepository.Users.SingleOrDefault(u => u.UserName == userName);
                        if(user.Roles.SingleOrDefault(r => r.Name == "No Access") != null)
                        {
                            context.RejectIdentity();
                        }
                        return System.Threading.Tasks.Task.FromResult(0);
                    }
                }
            });
        }
    }
