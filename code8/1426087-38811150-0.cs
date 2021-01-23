    public class BetterViewEngine : IViewLocationExpander
    {
       public void PopulateValues(ViewLocationExpanderContext context)
       {
            context.Values["customviewlocation"] = nameof(BetterViewEngine);
       }
    
       public IEnumerable<string> ExpandViewLocations(
            ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
       {
            return new[]
            {
                 "/folderName/{1}/{0}.cshtml",
                 "/folderName/Shared/{0}.cshtml"
            };
       }
    }
