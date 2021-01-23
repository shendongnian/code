    public void ReceiveMessageFromSubscription<T>(string topicPath, string subscriptionName, Action<T> action)
        {
            var client = SubscriptionClient.CreateFromConnectionString(ConnectionString, topicPath, subscriptionName);
            client.OnMessage((message) =>
            {
                try
                {
                    _logger.Information("Processing message");
                    action(message.GetBody<T>());
                    message.Complete();
                }
                catch(Exception ex)
                {
                    _logger.Error(ex, "Error processing message");
                    message.Abandon();
                }
            } );
        }
