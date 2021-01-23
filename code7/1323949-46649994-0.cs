        static void EventReceiver()
        {
            for (int i = 0; i <= EventHubPartitionCount; i++)
            {
                Task.Factory.StartNew((state) =>
                {
                    Console.WriteLine("Starting worker to process partition: {0}", state);
                    var factory = MessagingFactory.Create(ServiceBusEnvironment.CreateServiceUri("sb", "tests-eventhub", ""), new MessagingFactorySettings()
                    {
                        TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider("Listen", "PGSVA7L="),
                        TransportType = TransportType.Amqp
                    });
                    var client = factory.CreateEventHubClient("eventHubName");
                    var group = client.GetConsumerGroup("customConsumer");
                    Console.WriteLine("Group: {0}", group.GroupName);
                    var receiver = group.CreateReceiver(state.ToString(), DateTime.Now);
                    while (true)
                    {
                        if (cts.IsCancellationRequested)
                        {
                            receiver.Close();
                            break;
                        }
                        var messages = receiver.Receive(20);
                        messages.ToList().ForEach(aMessage =>
                        {                            
                             // Process your event
                        });
                        Console.WriteLine(counter);
                    }
                }, i);
            }
        }
