    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, IContainer container)
        {
            filters.Add(container.ResolveNamed<IActionFilter>("getUserActionFilter"));
            filters.Add(new HandleErrorAttribute());
        }
    }
