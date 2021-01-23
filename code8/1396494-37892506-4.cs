    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // Register the filter globally
            filters.Add(new ResourceFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
