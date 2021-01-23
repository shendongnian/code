    public interface IService 
    {
        void Execute();
    }
    
    public class ServiceA : IService
    {
        public void Execute() { ... }
    }
    
    class ServiceB : IService
    {
        public ServiceB(IService service)
        {
            Service = service;
        }
    
        public void Execute() { ... }
    
        public IService Servie { get; set; }
    }
