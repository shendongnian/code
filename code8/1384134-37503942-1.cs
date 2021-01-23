    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthorizationFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
