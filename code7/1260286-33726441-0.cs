    var eventConsumer = new EventingBasicConsumer(channel);
    eventConsumer.Received += (sender, args) =>
    {
     	var body = args.Body;
     	eventConsumer.Model.BasicAck(args.DeliveryTag, false);
    };
    channel.BasicConsume(queue, false, eventConsumer);
