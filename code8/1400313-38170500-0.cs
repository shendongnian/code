    public class LazyPipelineHandler<TContext> : PipelineHandler<TContext>
    {
        private readonly Lazy<IPipelineHandler<TContext>> innerHandler;
        public LazyPipelineHandler(Func<IPipelineHandler<TContext>> handlerFactory) 
        {
            this.innerHandler = new Lazy<IPipelineHandler<TContext>>(handlerFactory);
        }
        
        public override Task HandleAsync(TContext context, Func<TContext, Task> next) 
        {
            innerHandler.Value.Next = next;
            return innerHandler.Value.HandleAsync(context);
        }
    }
