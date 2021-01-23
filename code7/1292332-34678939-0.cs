    public class CustomFilterProvider : IFilterProvider
    {
        private readonly FilterProviderCollection _filterProviders;
        public CustomFilterProvider(IList<IFilterProvider> filters)
        {
            _filterProviders = new FilterProviderCollection(filters);
        }
        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = _filterProviders.GetFilters(controllerContext, actionDescriptor).ToArray();
            var shouldOverrideCustomAuthorizeAttribute = filters.Any(filter => filter.Instance is OverrideCustomAuthorizeAttribute);
            if (shouldOverrideCustomAuthorizeAttribute)
            {
                // There is an OverrideCustomAuthorizeFilterAttribute present, remove all CustomAuthorizeAttributes from the list of filters
                return filters.Where(filter => filter.Instance.GetType() != typeof(CustomAuthorizeAttribute));
            }
            return filters;
        }
    }
	
