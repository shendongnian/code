    public class ScopedCommandHandlerProxy<TCommand> : ICommandHandler<TCommand>
    {
        private readonly Func<ICommandHandler<TCommand>> decorateeFactory;
        private readonly Container container;
        // We inject a Func<T> that is able to create the command handler decoratee 
        // when needed.
        public ScopedCommandHandlerProxy(
            Func<ICommandHandler<TCommand>> decorateeFactory,
            Container container)
        {
            this.decorateeFactory = decorateeFactory;
            this.container = container;
        }
        public void Handle(TCommand command)
        {
            // Start some sort of 'scope' here that allows you to have a single 
            // instance of DbContext during that scope. How to do this depends 
            // on your DI library (if you use any).
            using (container.BeginLifetimeScope())
            {
                 // Create a wrapped handler inside the scope. This way it will get 
                 // a fresh DbContext.
                 ICommandHandler<TCommand> decoratee =this.decorateeFactory.Invoke();
                 // Pass the command on to this handler.
                 decoratee.Handle(command);
            }
        }
    }
