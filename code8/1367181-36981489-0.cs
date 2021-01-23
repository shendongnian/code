    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new RedirectActionFilter());
        }
    }
    public class RedirectActionFilter : IActionFilter
    {
        static Random rng = new Random();
        static bool GetBool() => rng.Next() % 2 == 0;
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (GetBool())
            {
                filterContext.Result = new RedirectResult("http://www.bbc.co.uk");
            }
            
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }
    }
