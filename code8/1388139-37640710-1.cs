    public class CompositeMessageHandler<T> : IMessageHandler<T> {
        private readonly IEnumerable<IMessageHandler<T>> handlers;
        public CompositeMessageHandler(IEnumerable<IMessageHandler<T>> handlers) {
            this.handlers = handlers;
        }
        public void Handle(T message) {
            foreach (var handler in this.handlers) {
                handler.Handle(message);
            }
        }
    }
