    public class GlobalFilterProvider : IFilterProvider
    {
        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var nestedContainer = StructuremapMvc.StructureMapDependencyScope.CurrentNestedContainer;
    
            foreach (var filter in nestedContainer.GetAllInstances<IActionFilter>())
            {
                yield return new Filter(filter, FilterScope.Global, order: null);
            }
    
            foreach (var filter in nestedContainer.GetAllInstances<IAuthorizationFilter>())
            {
                yield return new Filter(filter, FilterScope.Global, order: null);
            }
    
            foreach (var filter in nestedContainer.GetAllInstances<IExceptionFilter>())
            {
                yield return new Filter(filter, FilterScope.Global, order: null);
            }
    
            foreach (var filter in nestedContainer.GetAllInstances<IResultFilter>())
            {
                yield return new Filter(filter, FilterScope.Global, order: null);
            }
    
            foreach (var filter in nestedContainer.GetAllInstances<IAuthenticationFilter>())
            {
                yield return new Filter(filter, FilterScope.Global, order: null);
            }
        }
    }
