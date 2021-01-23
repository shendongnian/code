    public class FilterConfig
    {
       public static void RegisterGlobalFilters(GlobalFilterCollection filters)
       {
          filters.add(new LoginFilter());
       }
    }
