    [HubName("trackingHub")]
    public class TrackingHub : Hub
    {
        public void SendCount()
        {
            Clients.All.count(SignalRConnectionHandler.ConnectedUsers.Count);
        }
        public override Task OnConnected()
        {
            SignalRConnectionHandler.ConnectedUsers.Add(Context.ConnectionId);
            SendCount();
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            SignalRConnectionHandler.ConnectedUsers.Remove(Context.ConnectionId);
            SendCount();
            return base.OnDisconnected(stopCalled);
        }
        public override Task OnReconnected()
        {
            if (!SignalRConnectionHandler.ConnectedUsers.Contains(Context.ConnectionId))
            {
                SignalRConnectionHandler.ConnectedUsers.Add(Context.ConnectionId);
            }
            return base.OnReconnected();
        }
