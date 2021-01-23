    static void Main(string[] args)
    {
        var bus = Bus.Factory.CreateUsingRabbitMq(x =>
        {
            var host = x.Host(new Uri("rabbitmq://localhost/"), h => { });
            x.ReceiveEndpoint(host, "MtPubSubExample_TestSubscriber", e =>
                e.Consumer<SomethingHappenedConsumer>());
        });
        Console.WriteLine("Subscriber");
        var busHandle = bus.Start();
        Console.ReadKey();
        busHandle.Stop();
    }
