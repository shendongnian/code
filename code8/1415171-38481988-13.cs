    public class ServiceResponse { }
    public interface IService
    {
        ServiceResponse Execute();
    }
    public abstract class ServiceBase : IService
    {
        public ServiceResponse Execute()
        {
            if (_response == null)
            {
                _response = InnerExecute();
            }
            return _response;
        }
        public abstract ServiceResponse InnerExecute();
        private ServiceResponse _response;
    }
    public class ServiceA : ServiceBase
    {
        public override ServiceResponse InnerExecute()
        {
            return new ServiceResponse();
        }
    }
    public class ServiceB : ServiceBase
    {
        public ServiceB(IServiceFactory serviceFactory)
        {
            ServiceFactory= serviceFactory;
        }
        public override ServiceResponse InnerExecute()
        {
            //In this case it obviously makes more sense that the factory will have 
            //some key and that the `Get` will be by that key - This is only for simpler explanatory reasons 
            return ServiceFactory.GetServices()
                                 .Select(service => service.Execute());
        }
        public IServiceFactory ServiceFactory { get; set; }
    }
