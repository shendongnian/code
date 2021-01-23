    public interface IDomainEvents
    {
        void Raise<T>(T args) where T : IDomainEvent;
    }
    // NOTE: DomainEvents depends on Autofac and should therefore be placed INSIDE
    // your composition root.
    private class AutofacDomainEvents : IDomainEvents
    {
        private readonly IContainer container;
        public AutofacDomainEvents(IContainer container) {
            if (container == null) throw new ArgumentNullException("container");
            this.container = container;
        }
        public void Raise<T>(T args) where T : IDomainEvent {
            var handlers = this.container.Resolve<IEnumerable<IHandle<T>>>();
            foreach (var handler in handlers) {
                handler.Handle(args);
            }
        }
    }
