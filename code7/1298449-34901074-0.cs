    private static IHubContext hub = GlobalHost.ConnectionManager.GetHubContext<NotificationsHub>();
           
    public static void NotifyAllClients(string message)
    {
        hub.Clients.All.NotifyAllClients(message);
    }
