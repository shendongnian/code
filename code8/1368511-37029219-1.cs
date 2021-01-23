    // a component that uses IOwinContext as a dependency
    class CommandHandler
    {
        // this IOwinContext will be a different instance for each HttpRequest
        readonly IOwinContext _context;
        
        public CommandHandler(IOwinContext context)
        {
            _context = context;
        }
    }
    // capture our HttpRequest via the IOwinContext object
    var context = ...
    // create a nested scope
    using (var scope = Container.BeginLifetimeScope(builder =>
    {
        // register the Owin context for this specific HttpRequest
        builder.RegisterInstance(context).As<IOwinContext>();
    }))
    {
        // this component will be resolved with the specific IOwinContext
        // that we registered above
        var handler = scope.Resolve<CommandHandler>();
    }
