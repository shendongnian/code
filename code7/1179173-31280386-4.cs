    public class LifetimeScopeHandler<TRequest, TResponse> 
        : IHandle<TRequest, TResponse> where TRequest : class, IRequest<TResponse>
    {
        private readonly ILifetimeScope _scope;
        public LifetimeScopeHandler(ILifetimeScope scope)
        {
            this._scope = scope;
        }
        public TResponse Handle(TRequest request)
        {
            Console.WriteLine("LifetimeScopeDecoratorHandler");
            using (ILifetimeScope s = this._scope.BeginLifetimeScope("pipline"))
            {
                var decoratedHandler = 
                    s.ResolveKeyed<IHandle<TRequest, TResponse>>("FirstDecoratorHandler");
                TResponse response = decoratedHandler.Handle(request);
                return response;
            }
        }
    }
