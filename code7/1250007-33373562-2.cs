    public class UnityFilterProvider : ActionDescriptorFilterProvider, IFilterProvider
    {
        private readonly IUnityContainer _container;
        public UnityFilterProvider(IUnityContainer container)
        {
            _container = container;
        }
        public new IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            var attributes = base.GetFilters(configuration, actionDescriptor).ToList();
            
            foreach (var attr in attributes)
            {
                _container.BuildUp(attr.Instance.GetType(), attr.Instance);
            }
            return attributes;
        }
    }
