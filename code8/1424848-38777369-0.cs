    public void startServiceBusListener()
    {
    
        // setup subcsription
        var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);
        if (!namespaceManager.SubscriptionExists("myTopic", Environment.MachineName))
            namespaceManager.CreateSubscription("myTopic", Environment.MachineName);
    
        SubscriptionClient busClient = SubscriptionClient.CreateFromConnectionString(connectionString, "myTopic", Environment.MachineName);
    
        // Configure the callback options.
        OnMessageOptions options = new OnMessageOptions();
        options.AutoComplete = false;
        options.AutoRenewTimeout = TimeSpan.FromMinutes(1);
    
        receiveTask = Task.Run(() =>
        {
            // handle new messages
            busClient.OnMessage((message) =>
            {
                try
                {
                    Notification note = message.GetBody<Notification>();
                    string notification = JsonConvert.SerializeObject(note);
                    GlobalHost.ConnectionManager.GetHubContext<DispatchHub>().Clients.All.notify(notification);
                    // Remove message from subscription.
                    message.Complete();
                }
                catch (Exception)
                {
                    // Indicates a problem, unlock message in subscription.
                    message.Abandon();
                }
            }, options);
        }, cts.Token);
    }
