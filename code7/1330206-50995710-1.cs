    NamespaceManager nsManager = NamespaceManager.CreateFromConnectionString(<connectionstring>);
                var subscription = nsManager.GetSubscription(
                    <topicName>,<subscriptionName>);
    if(subscription != null && subscription.MessageCount > 0)
    //do something
