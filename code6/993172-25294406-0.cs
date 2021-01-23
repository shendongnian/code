    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        public override bool AuthorizeHubConnection(HubDescriptor hubDescriptor, IRequest request)
        {
            return IsValid(request.Headers["Token"]);
        }
        
        private static bool IsValid(string token)
        {
            // ...
        }
    }
    [HubName("stockTicker")]
    [MyAuthorize]
    public class StockTickerHub : Hub
    {
        // ...
    }
