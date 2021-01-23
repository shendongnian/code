    public class ContextualMessageHandlerDecorator<T> : IMessageHandler<T> {
        private readonly DecoratorContext context;
        private readonly IMessageHandler<T> decoratee;
        public ContextualMessageHandlerDecorator(DecoratorContext context,
            IMessageHandler<T> decoratee) {
            this.context = context;
            this.decoratee = decoratee;
        }
        public static string ContextNamespace { get; set; }
        public void Handle(T message) {
            // Here we get the ambient value from the ContextHelper and match it
            // with the namespace of the real message handler
            if (ContextHelper.ContextNamespace.Value.Equals(
                this.context.ImplementationType.Namespace)) {
                this.decoratee.Handle(message);
            }
        }
    }
    public static ContextHelper {
        public static readonly ThreadLocal<string> ContextNamespace =new ThreadLocal<string>();
    }
