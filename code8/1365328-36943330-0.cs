    static void Main(string[] args)
    {
        var bus = Bus.Factory.CreateUsingRabbitMq(x =>
        {
            var host = x.Host(new Uri("rabbitmq://localhost/"), h => { });
            x.ReceiveEndpoint(host, "MtPubSubExample_TestPublisher", e =>
                e.Consumer<ResponseConsumer>());
        });
        var busHandle = bus.Start();
        var text = "";
        Console.WriteLine("Publisher");
        while(text != "quit")
        {
            Console.Write("Enter a message: ");
            text = Console.ReadLine();
            var message = new SomethingHappenedMessage()
            {
                What = text,
                When = DateTime.Now
            };
            bus.Publish(message);
        }
        busHandle.Stop();
    }
