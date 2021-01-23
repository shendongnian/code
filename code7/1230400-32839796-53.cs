    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CultureFilter(defaultCulture: "nl"));
            filters.Add(new HandleErrorAttribute());
        }
    }
