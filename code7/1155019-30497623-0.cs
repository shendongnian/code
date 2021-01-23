    public interface IContainer<out T> : IContainer
    {
        new T Value { get; }
    }
    
    public interface IContainer
    {
        object Value { get; }
    }
