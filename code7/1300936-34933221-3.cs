    public class ViewLocationExpander : IViewLocationExpander
    {
        protected static IEnumerable<string> ExtendedLocations = new[]
        {
            "/{0}.cshtml"
        };
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            //nothing here
        }
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            //extend current view locations
            return viewLocations.Concat(ExtendedLocations);
        }
    }
