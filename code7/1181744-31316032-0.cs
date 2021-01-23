    public class LifetimeScopeMessageHandlerDecorator<T>
        : IMessageHandler<T>
    {
        private readonly Func<IMessageHandler<T>> decorateeFactory;
        public LifetimeScopeMessageHandlerDecorator(Container container,
            Func<IMessageHandler<T>> decorateeFactory) {
            this.decorateeFactory = decorateeFactory;
        }
        public void Handle(T message) {
            using (this.container.BeginLifetimeScope()) {
                var decoratee = this.decorateeFactory.Invoke();
                decoratee.Handle(message);
            }
        }
    }
