    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ConfigAuthorizationFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
