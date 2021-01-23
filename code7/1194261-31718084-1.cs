    public interface IService : IDisposable
    {
        void Serve(string message);
    }
    
    public interface IMessageHandler : IService
    {
    }
    
    public class MessageHandler : IMessageHandler
    {
        private readonly IWorkDispatcher workDispatcher;
    
        public MessageHandler (IServicesRegistry servicesRegistry)
        {
    	    servicesRegistry.RegisterService(WorkType.MessageHandler, this);
            this.servicesRegistry = servicesRegistry;
        }
        private void OnIncommingMessage(string message)
        {
            servicesRegistry.SendMessage(WorkType.Service, message);
        }
    
        public void Serve(string message) // was SendMessage(string message)
        {
            //sendMessage code
        }
    
        public void Dispose()
        {
    	    servicesRegistry.RemoveService(this);
        }
    }
    
    public interface IWorkerService : IService
    {
    }
    
    public class WorkerService: IWorkerService 
    {
        private readonly IServicesRegistry servicesRegistry
    
        public Service(IServicesRegistry servicesRegistry)
        {
    	    servicesRegistry.RegisterService(WorkType.Worker, this);
            this.servicesRegistry = servicesRegistry;
        }
        public void Serve(string message); // was DoWork(string work)
        {
            //Do Work
        }
    
        private void SomeMethodNeedsToPushData(string message)
        {
            servicesRegistry.SendMessage(WorkType.MessageHandler, message);
        }
    
        public void Dispose()
        {
    	    servicesRegistry.RemoveService(this);
        }
    }
    public enum WorkType
    {
        Service,
        MessageHandler
    }
    public interface IServicesRegistry
    {
        void RegisterService(WorkType workType, IService service);
        void RemoveService(IService service);
        void QueueWork(WorkType workType, string message);
    }
