    string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
    var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);
    // Create the topic
    namespaceManager.CreateTopic("TestTopic");
    // Create subscription to handle message A
    namespaceManager.CreateSubscription("TestTopic", "MessageA", new SqlFilter("messageType = 'MessageA'"));
    // Create subscription to handle message A
    namespaceManager.CreateSubscription("TestTopic", "MessageB", new SqlFilter("messageType = 'MessageB'"));
