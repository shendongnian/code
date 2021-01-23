    public enum ServicesTypes 
    {
        ServiceA,
        ServiceB....
    }
    public interface IServiceFactory
    {
        IEnumerable<IService> GetServices();
        IService GetServices(ServicesTypes servicesTypes);
    }
       
    public class SomeOtherThatExecuteServices
    {
        public SomeOtherThatExecuteServices(IServiceFactory serviceFactory)
        {
            ServiceFactory = serviceFactory;
        }
        public IEnumerable<ServiceResponse> ExecuteServices()
        {
            return ServiceFactory.GetServices()
                                 .Select(service => service.Execute());
        }
        public IServiceFactory ServiceFactory { get; set; }
    }
