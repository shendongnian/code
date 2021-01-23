    public class ServiceInterface : Service
    {
        public IDevice DeviceAdapter { get; set; }         
        
        public object Any(Request request)
        {
            //DeviceAdapter also has access to IServerEvents
            DeviceAdapter.Exec(request); 
        }
    }
