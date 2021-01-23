    public class ScopedMessagingProvider : MessagingProvider
    {
        private readonly ServiceBusConfiguration _config;
        private readonly Container _container;
        public ScopedMessagingProvider(ServiceBusConfiguration config, Container container)
            : base(config)
        {
            _config = config;
            _container = container;
        }
        public override MessageProcessor CreateMessageProcessor(string entityPath)
        {
            return new CustomMessageProcessor(_config.MessageOptions, _container);
        }
        private class CustomMessageProcessor : MessageProcessor
        {
            private readonly Container _container;
            public CustomMessageProcessor(OnMessageOptions messageOptions, Container container)
                : base(messageOptions)
            {
                _container = container;
            }
            public override Task<bool> BeginProcessingMessageAsync(BrokeredMessage message, CancellationToken cancellationToken)
            {
                _container.BeginExecutionContextScope();
                return base.BeginProcessingMessageAsync(message, cancellationToken);
            }
            public override Task CompleteProcessingMessageAsync(BrokeredMessage message, FunctionResult result, CancellationToken cancellationToken)
            {
                var scope = _container.GetCurrentExecutionContextScope();
                if (scope != null)
                {
                    scope.Dispose();
                }
                
                return base.CompleteProcessingMessageAsync(message, result, cancellationToken);
            }
        }
    }
