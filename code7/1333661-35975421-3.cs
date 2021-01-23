    public interface IMessageDispatcher
    {
        void Dispatch<TMessage>(TMessage msg);
    }
    
    // The actual implementation differs
    // depending on your choice of container.
    public class ContainerBasedMessageDispatcher : IMessageDispatcher
    {
        Container _container;
    
        public ContainerBasedMessageDispatcher(Container container)
        {
            _container = container;
        }
        public void Dispatch<TMessage>(TMessage message)
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var handlers = scope.Resolve<IEnumerable<IMessageHandler<TMessage>>();
                foreach (var handler in handlers)
                {
                    handler.Handle(message);
                }
            }
        }
    }
