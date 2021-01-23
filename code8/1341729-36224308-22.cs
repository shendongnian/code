    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // Register the filter provider with MVC.
            FilterProviders.Providers.Insert(0, new GlobalFilterProvider(DependencyResolver.Current));
        }
    }
