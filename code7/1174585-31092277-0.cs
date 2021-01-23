    private sealed class CacheDependencyFactory : ICacheDependencyFactory {
        private readonly Container container;
        public CacheDependencyFactory(Container container) {
            this.container = container;
        }
        public ICacheDependency Create() {
            return this.container.GetInstance<ICacheDependency>();
        }
    }
