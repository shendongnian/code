    public void CreateSubFilter(String TopicName, String SubscriptionName)
            { 
                var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);
                namespaceManager.CreateSubscription(TopicName, SubscriptionName);
             
            }
