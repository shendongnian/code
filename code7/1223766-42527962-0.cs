    using Microsoft.AspNet.SignalR;
    namespace SignalRChat
    {
        public class ChatHub : Hub
        {
            public void Send(string name, string message)
            {
                // Two argument must use this interfaceSubscriptionHandler2 .
                Clients.All.broadcastMessage(name, message);
            }
          
        }
    }
