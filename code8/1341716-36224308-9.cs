    public class GlobalFilterProvider : IFilterProvider
    {
        private readonly IDependencyResolver dependencyResolver;
        public GlobalFilterProvider(IDependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;
        }
        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            foreach (var filter in this.dependencyResolver.GetServices<IActionFilter>())
            {
                yield return new Filter(filter, FilterScope.Global, order: null);
            }
            foreach (var filter in this.dependencyResolver.GetServices<IAuthorizationFilter>())
            {
                yield return new Filter(filter, FilterScope.Global, order: null);
            }
            foreach (var filter in this.dependencyResolver.GetServices<IExceptionFilter>())
            {
                yield return new Filter(filter, FilterScope.Global, order: null);
            }
            foreach (var filter in this.dependencyResolver.GetServices<IResultFilter>())
            {
                yield return new Filter(filter, FilterScope.Global, order: null);
            }
            // If MVC 5, add these as well...
            //foreach (var filter in this.dependencyResolver.GetServices<System.Web.Mvc.Filters.IAuthenticationFilter>())
            //{
            //    yield return new Filter(filter, FilterScope.Global, order: null);
            //}
        }
    }
