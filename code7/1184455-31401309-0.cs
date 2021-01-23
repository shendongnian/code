    static void Main()
    {
        var change = new MessageType1();
        var advancedBus = RabbitHutch.CreateBus("host=localhost").Advanced;
        ConsumeMessage(advancedBus);
        var queue = advancedBus.QueueDeclare("MyQueue");
        if (advancedBus.IsConnected)
        {
            advancedBus.Publish(Exchange.GetDefault(), queue.Name, true, false,
                new Message<MessageType1>(change));
        }
        else
        {
            Console.WriteLine("Can't connect");
        }
        Console.ReadKey();
    }
    private static void ConsumeMessage(IAdvancedBus advancedBus)
    {
        var queue = advancedBus.QueueDeclare("MyQueue");
        advancedBus.Consume(queue, registration =>
        {
            registration.Add<MessageType1>((message, info) =>
            {
                Console.WriteLine("Body: {0}", message.Body);
            });
        });
    }
