    public class PermissionFilterProvider : IFilterProvider
    {
        private readonly Func<PermissionFilter> _permissionFilterFactory = null;
        public PermissionFilterProvider(Func<PermissionFilter> filterFactory)
        {
            _permissionFilterFactory = filterFactory;
        }
        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = new List<Filter>(); 
            // instantiate PermissionFilter action filter  
            filters.Add(new Filter(_permissionFilterFactory(), FilterScope.Action, 0));
            return filters;
        }
    }
