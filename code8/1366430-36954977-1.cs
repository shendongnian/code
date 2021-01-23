    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;
    
    namespace SignalR.Code
    {
        [HubName("signalhub")]
        public class SignalRHub : Hub
        {
            public void BroadcastMessage(string message)
            {            
                Clients.Client(Context.ConnectionId).Send(message);
            }
        }
    }
