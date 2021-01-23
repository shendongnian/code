    var factory = new ConnectionFactory
    {
        HostName = "localhost",
        DispatchConsumersAsync = true
    };
    using(var connection = cf.CreateConnection())
    {
        using(var channel = conn.CreateModel())
        {
            channel.QueueDeclare("testqueue", true, false, false, null);
            var consumer = new AsyncEventingBasicConsumer(model);
            consumer.Received += async (o, a) =>
            {
                Console.WriteLine("Message Get" + a.DeliveryTag);
                await Task.Yield();
            };
        }
        Console.ReadLine();
    }
