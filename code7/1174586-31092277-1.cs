    private sealed class CacheDependencyFactory : ICacheDependencyFactory {
        private readonly Container container;
        public CacheDependencyFactory(Container container) {
            this.container = container;
        }
        public T Create<T>() where T : ICacheDependency, class {
            return this.container.GetInstance<T>();
        }
    }
