    [HubName("PushHub")]
    public class PushHub : Hub
    {
        IHubContext connectionHub = GlobalHost.ConnectionManager.GetHubContext<PushConnection>();
    public void Send(Payload payload)
    {
            connectionHub.Clients.All.Notify(payLoad);
    }
    }
