    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LocalizationFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
