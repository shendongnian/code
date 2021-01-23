    namespace SignalRDemo
    {
        public class ChatHub : Hub
        {
            private static ConcurrentDictionary<string, string> FromUsers = new ConcurrentDictionary<string, string>();         // <connectionId, userName>
            private static ConcurrentDictionary<string, string> ToUsers = new ConcurrentDictionary<string, string>();           // <userName, connectionId>
            private string userName = "";
        public override Task OnConnected()
        {
            DoConnect();
            Clients.AllExcept(Context.ConnectionId).broadcastMessage(new ChatMessage() { UserName = userName, Message = "I'm Online" });
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            if (stopCalled) // Client explicitly closed the connection
            {
                string id = Context.ConnectionId;
                FromUsers.TryRemove(id, out userName);
                ToUsers.TryRemove(userName, out id);
                Clients.AllExcept(Context.ConnectionId).broadcastMessage(new ChatMessage() { UserName = userName, Message = "I'm Offline" });
            }
            else // Client timed out
            {
                // Do nothing here...
                // FromUsers.TryGetValue(Context.ConnectionId, out userName);            
                // Clients.AllExcept(Context.ConnectionId).broadcastMessage(new ChatMessage() { UserName = userName, Message = "I'm Offline By TimeOut"});                
            }
            return base.OnDisconnected(stopCalled);
        }
        public override Task OnReconnected()
        {
            DoConnect();
            Clients.AllExcept(Context.ConnectionId).broadcastMessage(new ChatMessage() { UserName = userName, Message = "I'm Online Again" });
            return base.OnReconnected();
        }
        private void DoConnect()
        {
            userName = Context.Request.Headers["User-Name"];
            if (userName == null || userName.Length == 0)
            {
                userName = Context.QueryString["User-Name"]; // for javascript clients
            }
            FromUsers.TryAdd(Context.ConnectionId, userName);
            String oldId; // for case: disconnected from Client
            ToUsers.TryRemove(userName, out oldId);
            ToUsers.TryAdd(userName, Context.ConnectionId);
        }
        public void Send(string message)
        {
            // Call the broadcastMessage method to update clients.            
            string fromUser;
            FromUsers.TryGetValue(Context.ConnectionId, out fromUser);
            Clients.AllExcept(Context.ConnectionId).broadcastMessage(new ChatMessage() { UserName = fromUser, Message = message });
        }
        public void SendChatMessage(string to, string message)
        {
            FromUsers.TryGetValue(Context.ConnectionId, out userName);
            string receiver_ConnectionId;
            ToUsers.TryGetValue(to, out receiver_ConnectionId);
            if (receiver_ConnectionId != null && receiver_ConnectionId.Length > 0)
            {
                Clients.Client(receiver_ConnectionId).broadcastMessage(new ChatMessage() { UserName = userName, Message = message });
            }
        }        
    }
    public class ChatMessage
    {
        public string UserName { get; set; }
        public string Message { get; set; }
    }
    }
