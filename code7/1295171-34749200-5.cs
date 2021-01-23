    public abstract class ProcessorFactoryBase<TItem> : IProcessorFactory
    {
        private Lazy<IProcessor> _factory;
        public ProcessorFactoryBase(Func<IProcessor> factory)
        {
            _factory = new Lazy<IProcessor>(factory);
        }
        public Type ItemType
        {
            get { return typeof(TItem); }
        }
        public IProcessor GetProcessor()
        {
            return _factory.Value;
        }
    }
