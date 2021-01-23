        public class TriggeredJob
        {
            private readonly Container _container;
            public TriggeredJob(Container container)
            {
                _container = container;
            }
            public async Task TriggeredFunction([ServiceBusTrigger("queueName")] BrokeredMessage message, CancellationToken token)
            {
                using (var scope = _container.BeginExecutionContextScope())
                {
                    var processor = _container.GetInstance<IBrokeredMessageProcessor>();
                    await processor.ProcessAsync(message, token);
                }
            }
        }
