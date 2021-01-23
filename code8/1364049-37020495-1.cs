    public class HubActivator : IHubActivator
    {
        private readonly IUnityContainer _container;
        private readonly IHubContainer<ExecutionReportsHub> _hubContainer;
    
        public HubActivator(IUnityContainer container)
        {
            _container = container;
            _hubContainer = container.Resolve<IHubContainer<ExecutionReportsHub>>();
        }
    
        public IHub Create(HubDescriptor descriptor)
        {
            object hub = _container.Resolve(descriptor.HubType) ?? Activator.CreateInstance(descriptor.HubType);
            if (hub is ExecutionReportsHub)
            {
                _hubContainer.Add(hub as ExecutionReportsHub);
            }
            return hub as IHub;
        }
    }
    
    public class ExecutionReportsHubContainer : IHubContainer<ExecutionReportsHub>
    {
        public ExecutionReportsHubContainer()
        {
            _hubs = new List<ExecutionReportsHub>();
        }
    
        private  IList<ExecutionReportsHub> _hubs { get; set; }
    
        public void Add(ExecutionReportsHub hub)
        {
            _hubs.Add(hub);
        }
    
        public void Remove(ExecutionReportsHub hub)
        {
            _hubs.Remove(hub);
        }
    
        public void Dispose(string connectionId)
        {
            IEnumerable<ExecutionReportsHub> hubs = _hubs.Where(x => x.ConnectionId.Equals(connectionId)).ToList();
            foreach (var hub in hubs)
            {
                hub.Detach();
                Remove(hub);
                hub.Dispose();
            }
        }
    }
    
    public interface IHubContainer<T> where T : IHub
    {
        void Dispose(string connectionId);
        void Remove(IFlowHub flowHub);
        void Add(IFlowHub flowHub);
    }
