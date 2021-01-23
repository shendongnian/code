    public class NotificationsHub : Hub
    {
        public void NotifyAllClients(string s_Not, DateTime d_LastRun)
        {
           IHubContext context = GlobalHost.ConnectionManager.GetHubContext<NotificationsHub>();
           context.Clients.All.displayNotification(s_Not, d_LastRun);
        }
    }
