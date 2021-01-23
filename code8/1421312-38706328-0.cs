    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;
    
    namespace SignalR.Web.Authorization
    {
        public class HeadersAuthAttribute : AuthorizeAttribute
        {
            private const string UserIdHeader = "SRUserId";
    
            public override bool AuthorizeHubConnection(HubDescriptor hubDescriptor, IRequest request)
            {
                if (string.IsNullOrEmpty(request.Headers[UserIdHeader]))
                {
                    return false;
                }
    
                return true;
            }
        }
    }
