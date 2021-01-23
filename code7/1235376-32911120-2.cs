    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, IContainer container)
        {
            filters.Add(container.ResolveNamed<IActionFilter>("action1DebugActionWebApiFilter"));
            filters.Add(new HandleErrorAttribute());
        }
    }
