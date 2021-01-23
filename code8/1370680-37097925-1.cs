    using Silly.Services.CarPark;
    using Silly.Services.CarPark.ServiceContracts.Common.v1;
    using log4net;
    using System.Linq;
    using System.Threading.Tasks;
    using WcfClientProxyGenerator;
    namespace Silly.Services.CarPark.Client
    {
        public class RequestManager : ClientBase<IRequestService>, IRequestService
        {
            public RequestManager() : 
                  base("BasicHttpBinding_IRequestService")
            {
            }
            // Implementation of IRequestService methods
            public string Alpha(...) {
              return Proxy.Alpha(...);  
            }
            public void Beta(...) {
                  Proxy.Beta(...);
            }
        }
    }
