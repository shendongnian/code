    [HubName("trackingHub")]
    public class TrackingHub : Hub
    {
        public void SendCount()
        {   // Send the ConnectedUsers count to the caller
            Clients.All.count(SignalRConnectionHandler.ConnectedUsers.Count);
        }
        public override Task OnConnected()
        {
            // When a user connects, add him to the HashSet
            SignalRConnectionHandler.ConnectedUsers.Add(Context.ConnectionId);
            SendCount();
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            // When a user disconnects, remove him to the Hashset
            SignalRConnectionHandler.ConnectedUsers.Remove(Context.ConnectionId);
            SendCount();
            return base.OnDisconnected(stopCalled);
        }
        public override Task OnReconnected()
        {
            // When a user reconnects, Check if he is already in the Hashset, if not add him back in.
            if (!SignalRConnectionHandler.ConnectedUsers.Contains(Context.ConnectionId))
            {
                SignalRConnectionHandler.ConnectedUsers.Add(Context.ConnectionId);
            }
            return base.OnReconnected();
        }
