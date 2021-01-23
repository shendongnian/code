    private static async void SendTemplateNotificationAsync()
    {
        // Define the notification hub.
        NotificationHubClient hub = 
            NotificationHubClient.CreateClientFromConnectionString(
                "<connection string with full access>", "<hub name>");
    
        // Sending the notification as a template notification. All template registrations that contain 
        // "messageParam" or "News_<local selected>" and the proper tags will receive the notifications. 
        // This includes APNS, GCM, WNS, and MPNS template registrations.
        Dictionary<string, string> templateParams = new Dictionary<string, string>();
    
        // Create an array of breaking news categories.
        var categories = new string[] { "World", "Politics", "Business", "Technology", "Science", "Sports"};
        var locales = new string[] { "English", "French", "Mandarin" };
    
        foreach (var category in categories)
        {
            templateParams["messageParam"] = "Breaking " + category + " News!";
    
            // Sending localized News for each tag too...
            foreach( var locale in locales)
            {
                string key = "News_" + locale;
    
                // Your real localized news content would go here.
                templateParams[key] = "Breaking " + category + " News in " + locale + "!";
            }
    
            await hub.SendTemplateNotificationAsync(templateParams, category);
        }
    }
