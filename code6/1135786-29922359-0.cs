    AzureServiceBus.QueueClient.OnMessage((message) =>
                {
                    try
                    {
                        // Process message from queue
                        Trace.WriteLine("Message received: " + ((BrokeredMessage)message).Label);
    
                        var breezeController = new BreezeController();
                        breezeController.TestSignal();
    
                        // Remove message from queue
                        message.Complete();
                    }
                    catch (Exception)
                    {
                        // Indicates a problem, unlock message in queue
                        message.Abandon();
                    }
                });
