    private sealed class SimpleInjectorUnitOfWork : IUnitOfWork {
        private readonly Container _container;
        public UnitOfWork(Container container){
            _container = container;
        }
        public IReadRepository<T> Read<T>() => _container.GetInstance<IReadRepository<T>>();
        public IWriteRepository<T> Write<T>() => _container.GetInstance<IWriteRepository<T>>();
    }
