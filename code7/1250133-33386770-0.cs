    var client = HareDuFactory.New(x => x.ConnectTo(RabbitMqHostUrl));
    var data = client
                .Factory<VirtualHostResources>(y => y.Credentials(RabbitMqUser, RabbitMqPass))
                .Queue
                .GetAll()
                .Data();
            
    foreach (var queue in data)
    {
    /*then you can access                
    queue.Name, queue.VirtualHostName, queue.Memory, queue.Messages,
    queue.MessagesReady, queue.MessagesUnacknowledged, queue.Node, queue.IsDurable, queue.Consumers, queue.IdleSince */
    }
