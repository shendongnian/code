    public class IoCConfig
    {
        public static void RegisterIoC(IAppBuilder app)
        {
            // Create the container as usual.
            Container container = new Container();
            // Registering as a factory delegate because we need the user authentication information if any.
            container.RegisterSingle<Func<IMyClient>>(() =>
            {
                string apiKey = ConfigurationManager.AppSettings["ApiKey"];
                var myClient = new MyClient(apiKey);
                if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
                {
                    var identity = Thread.CurrentPrincipal.Identity as ClaimsIdentity;
                    var tokenClaim = identity.Claims.First(c => c.Type == ClaimTypes.Sid);
                    myClient.AddCredentials(tokenClaim.Value);
                }
                return myClient;
            });
            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            // This is an extension method from the integration package as well.
            container.RegisterMvcIntegratedFilterProvider();
            container.Verify();
            DependencyResolver.SetResolver(
        new SimpleInjectorDependencyResolver(container));
        }
    }
