    public class MessagesHub : Hub
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
        
        [HubMethodName("sendMessages")]
        public void SendMessages()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MessagesHub>();
            context.Clients.All.updateMessages();
        }
    }
