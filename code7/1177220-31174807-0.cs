    public class NewsFeedHub : Hub 
    {
        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NewsFeedHub>();
    
        // Call this from JS: hub.client.send(channel, content)
        public void Send(string channel, string content)
        {
            Clients[channel].addMessage(content);
        }
    
        // Call this from C#: NewsFeedHub.Static_Send(channel, content)
        public static void Static_Send(string channel, string content)
        {
            hubContext.Clients[channel].addMessage(content);
        }
    }
