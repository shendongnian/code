    var busControl = Bus.Factory.CreateUsingRabbitMq(x =>
    {
        x.AutoDelete = false;
        x.UseJsonSerializer();
        x.UseTransaction();
        x.ExchangeType = "direct";
        x.Durable = true;
        var host = x.Host(new Uri("rabbitmq://localhost/"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        x.UseRetry(Retry.Immediate(2));
        x.ReceiveEndpoint("Dev_Queue", e =>
        {
            e.Consumer(() => new MyConsumer());
        })
    });
