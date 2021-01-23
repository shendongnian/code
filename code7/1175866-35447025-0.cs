    public class MyHub : Hub
    {
        public override Task OnConnected()
        {
            signalConnectionId(this.Context.ConnectionId);
            return base.OnConnected();
        }
        private void signalConnectionId(string signalConnectionId)
        {
            Clients.Client(signalConnectionId).signalConnectionId(signalConnectionId);
        }
    }
