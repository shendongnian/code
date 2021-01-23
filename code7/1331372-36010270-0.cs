       string notificationHubName = "xxxxxxx";
        string notificationHubConnection = "Endpoint=sb://xxxxxx";
         hub = NotificationHubClient.CreateClientFromConnectionString(notificationHubConnection, notificationHubName, true);
        Dictionary<string, string> notification = new Dictionary<string, string>()
        {
            {"messageParam", "It works. Tap to view."}
        };
        var task = hub.SendTemplateNotificationAsync(notification);
        task.Wait();
