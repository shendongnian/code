    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute()); // Removed because ELMAH reports "cannot find Shared/Error" view instead of the exception.
        }
    }
