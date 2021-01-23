    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //Add this line
            filters.Add(new AuthorizeAttribute());
        }
    }
