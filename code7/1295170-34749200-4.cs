    public interface IProcessorFactory
    {
        Type ItemType { get; }
        IProcessor GetProcessor();
    }
