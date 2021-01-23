    // Abstraction: Part of your core library
    public interface IFactory<TResult>
    {
        TResult Create(Type type);
    }
    // Implementation: Part of your composition root
    private sealed CreateFuncFactory<TResult> : IFactory<TResult>
    {
        // Since we're in the Composition Root, its okay to depend
        // on the container here. See: https://bit.ly/1mdaLYG 
        private readonly IUnityContainer container;
        public CreateFuncFactory(IUnityContainer container) {
            this.container = container;
        }
        public TResult Create(Type type) {
            return (TResult)container.Resolve(type);
        }
    }
