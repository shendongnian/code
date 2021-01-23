    public class NewsFeedHub : Hub 
    {
        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NewsFeedHub>();
    
        // Call this from JS: hub.client.send(channel, content)
        public void Send(string groupName, string content)
        {
            Clients.Group(groupName).addMessage(content);
        }
    
        // Call this from C#: NewsFeedHub.Static_Send(groupName, content)
        public static void Static_Send(string groupName, string content)
        {
            hubContext.Clients.Group(groupName).addMessage(content);
        }
    }
