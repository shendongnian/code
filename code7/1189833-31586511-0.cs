    public class MultiAssemblyViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            var actionContext = (ResultExecutingContext)context.ActionContext;
            var assembly = actionContext.Controller.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            foreach (var viewLocation in viewLocations)
                yield return "/" + assemblyName + viewLocation;
        }
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            
        }
    }
