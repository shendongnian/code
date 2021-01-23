    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CultureFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
