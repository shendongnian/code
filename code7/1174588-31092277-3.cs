    private sealed class CacheDependencyFactory : ICacheDependencyFactory {
        public Container Container { get; set; }
        public T Create<T>() where T : ICacheDependency, class {
            return this.Container.GetInstance<T>();
        }
    }
