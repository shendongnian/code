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
            return ServiceFactory.GetServices(ServicesTypes.ServiceA).Execute();
        }
        public IServiceFactory ServiceFactory { get; set; }
    }
