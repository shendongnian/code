    public class DiscoveryService
    {
        private readonly IService _service;
    
        private ServiceHost _serviceHost;
    
        public DiscoveryService(IService service)
        {
            _service = service;
    
            // ...
        }
    
        private void StartServerMode()
        {
            _serviceHost = new ServiceHost(_service);
            _serviceHost.Open();
            // ...
        }
    }
