    public class ViewLocationRemapper : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            return new[]
            {
                "/Views/{1}/{0}.cshtml",
                "/Views/Shared/{0}.cshtml",
                "/Views/" + context.Values["admin"] + "/{1}/{0}.cshtml"
            };
        }
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values["admin"] = "AdminViews";
        }
    }
