    string ConnectionString = "<EventHub-Compatible-EndPoint>;SharedAccessKeyName=iothubowner;SharedAccessKey<Key>
        static string eventHubEntity = "<EventHub-Compatible-Name>";
        string partitionId = "0";
        DateTime startingDateTimeUtc;
        EventHubConsumerGroup group;
        EventHubClient client;
        MessagingFactory factory;
        EventHubReceiver receiver;
    public async Task ReceiveDataFromCloud()
        {
            startingDateTimeUtc = DateTime.UtcNow;
            ServiceBusConnectionStringBuilder builder = new ServiceBusConnectionStringBuilder(ConnectionString);
            builder.TransportType = ppatierno.AzureSBLite.Messaging.TransportType.Amqp;
            factory = MessagingFactory.CreateFromConnectionString(ConnectionString);
            client = factory.CreateEventHubClient(eventHubEntity);
            group = client.GetDefaultConsumerGroup();
            receiver = group.CreateReceiver(partitionId.ToString(), startingDateTimeUtc);//startingDateTimeUtc
            while (true)
            {
                EventData data = receiver.Receive();
                if (data != null)
                {
                    var receiveddata = Encoding.UTF8.GetString(data.GetBytes());
                    Debug.WriteLine("{0} {1} {2}", data.SequenceNumber, data.EnqueuedTimeUtc.ToLocalTime(), Encoding.UTF8.GetString(data.GetBytes()));
                }
                else
                {
                    break;
                }
                
                await Task.Delay(2000);
            }
            receiver.Close();
            client.Close();
            factory.Close();
            
        }
