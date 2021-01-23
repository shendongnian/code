    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()); // Or whatever filter you got.
            filters.Add(new AjaxExceptionLoggingFilter());
        }
    }
