    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string GetData(int value);
    }
    public class Service : IService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
    }
    public class ServiceValidationDecorator : IService
    {
        private readonly IService m_DecoreatedService;
        public ServiceValidationDecorator(IService decoreated_service)
        {
            m_DecoreatedService = decoreated_service;
        }
        public string GetData(int value)
        {
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            
            WebHeaderCollection headers = request.Headers;
            //Here use the headers to do you custom validation
            bool valid = ...
            if(!valid)
                throw new SecurityException("Access Denied");
            return m_DecoreatedService.GetData(value);
        }
    }
