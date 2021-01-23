    public class Notifications
    {
        public NotificationHubClient Hub { get; set; }
        public Notifications(string connString, string hubName) {
            Hub = NotificationHubClient.CreateClientFromConnectionString(
            connString, hubName);
        }
    }
