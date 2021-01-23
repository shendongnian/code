    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Some other stuff first....
            var providers = FilterProviders.Providers.ToArray();
            FilterProviders.Providers.Clear();
            FilterProviders.Providers.Add(new CustomFilterProvider(providers));
        }
    }
