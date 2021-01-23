    using Microsoft.AspNet.Mvc.Razor;
    using System.Collections.Generic;
    using System.Linq;
    
    public class RazorViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context) { }
    
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            List<string> locations = viewLocations.ToList();
    
            locations.Add("/Areas/dashboard/Views/Shared/{0}.cshtml");
    
            return locations;
        }
    }
