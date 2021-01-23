    string connectionString = CloudConfigurationManager.GetSetting("ServiceBus.ConnectionString");
    // Note issue of how you secure this if necessary
    var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);
    
    if (!namespaceManager.SubscriptionExists(TOPIC_NAME, SUBSCRIPTION_NAME))
    {
        //var messagesFilter = new SqlFilter("you can add a client filter for the subscription");
        SubscriptionDescription sd = new SubscriptionDescription(TOPIC_NAME, SUBSCRIPTION_NAME)
        {
            // configure settings or accept the defaults
            DefaultMessageTimeToLive = TimeSpan.FromDays(14),
            EnableDeadLetteringOnMessageExpiration = true,
            MaxDeliveryCount = 1000,
            LockDuration = TimeSpan.FromMinutes(3)
        };
        namespaceManager.CreateSubscription(sd);
    	// or namespaceManager.CreateSubscription(sd, messagesFilter);
    }
    // subscription client for the new topic
    _subscriptionClient = SubscriptionClient.CreateFromConnectionString(connectionString, TOPIC_NAME, SUBSCRIPTION_NAME, ReceiveMode.PeekLock);
