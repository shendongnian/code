    public partial class Startup
         {
             
            public static IDataProtectionProvider DataProtectionProvider { get; private set; }
            public void ConfigureAuth(IAppBuilder app)
            {
                // add this assignment
                DataProtectionProvider = app.GetDataProtectionProvider();
                 // Configure the db context, user manager and signin manager to use a single instance per request
                app.CreatePerOwinContext(SampleDataContext.Create);
               
                app.CreatePerOwinContext(() => DependencyResolver.Current.GetService<ApplicationUserManager>());
                 app.CreatePerOwinContext(() => DependencyResolver.Current.GetService<ApplicationSignInManager>());
                 
             }
         }
