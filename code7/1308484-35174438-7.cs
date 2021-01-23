    public class MessagesHub : Hub
    {
        [HubMethodName("sendMessages")]
        public void SendMessages()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MessagesHub>();
            context.Clients.All.updateMessages();
        }
    }
