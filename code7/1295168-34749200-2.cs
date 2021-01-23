    public abstract class ProcessorFactory
    {
        public abstract Type ItemType { get; }
        public abstract IProcessor GetProcessor();
    }
