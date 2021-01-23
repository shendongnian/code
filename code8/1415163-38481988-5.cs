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
        public ServiceB(IService service)
        {
            Service = service;
        }
        public override ServiceResponse InnerExecute()
        {
            //Do whatever operations you want while using the given dependent-upon service
            return Service.Execute();
        }
        public IService Service { get; set; }
    }
