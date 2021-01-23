    public class LifetimeScopeHandler<TRequest, TResponse> 
        : IHandle<TRequest, TResponse> where TRequest : class, IRequest<TResponse>
    {
        private readonly ILifetimeScope _scope;
        private readonly String _previousHandlerName; 
        public LifetimeScopeHandler(ILifetimeScope scope, String previousHandlerName)
        {
            this._scope = scope;
            this._previousHandlerName = previousHandlerName; 
        }
        public TResponse Handle(TRequest request)
        {
            Console.WriteLine("LifetimeScopeDecoratorHandler");
            using (ILifetimeScope s = this._scope.BeginLifetimeScope("pipline"))
            {
                var decoratedHandler = 
                    s.ResolveKeyed<IHandle<TRequest, TResponse>>(previousHandlerName);
                TResponse response = decoratedHandler.Handle(request);
                return response;
            }
        }
    }
