    class ResponseConsumer : IConsumer<IResponse>
    {
        public Task Consume(ConsumeContext<IResponse> context)
        {
            Console.WriteLine("RESPONSE MESSAGE: " + context.Message.Message);
            return Task.FromResult(0);
        }
    }
