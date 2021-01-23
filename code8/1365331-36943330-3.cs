    class SomethingHappenedConsumer : IConsumer<ISomethingHappened>
    {
        private IBusControl bus = Bus.Factory.CreateUsingRabbitMq(x =>
            x.Host(new Uri("rabbitmq://localhost/"), h => { }));
        public Task Consume(ConsumeContext<ISomethingHappened> context)
        {
            var now = DateTime.Now;
            Console.Write("TXT: " + context.Message.What);
            Console.Write("  SENT: " + context.Message.When);
            Console.Write("  PROCESSED: " + now);
            Console.WriteLine(" (" + System.Threading.Thread.CurrentThread.ManagedThreadId + ")");
            var response = new ResponseMessage()
            {
                Message = "The request was processed at " + now
            };
            bus.Publish(response);
            return Task.FromResult(0);
        }
    }
