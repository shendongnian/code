    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, IKernel container)
        {
		    // Register our filter globally with dependencies
            filters.Add(container.Get<CurrentUserProfileFilter>());
            filters.Add(new HandleErrorAttribute());
        }
    }
