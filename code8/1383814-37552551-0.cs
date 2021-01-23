            var nsManager = NamespaceManager.CreateFromConnectionString(ConnectionString);
            if (!await nsManager.TopicExistsAsync(TopicName))
            {
                await nsManager.CreateTopicAsync(TopicName);
            }
            if (!await nsManager.SubscriptionExistsAsync(TopicName, SubscriptionName))
            {
                await nsManager.CreateSubscriptionAsync(TopicName, SubscriptionName);
            }
            var subDesc = await nsManager.GetSubscriptionAsync(TopicName, SubscriptionName);
            subDesc.ForwardTo = "myTopic2";
            await nsManager.UpdateSubscriptionAsync(subDesc);
