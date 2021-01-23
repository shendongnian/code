    public interface IHasOperatingSystem<T> where T : IOperatingSystem
    {
        T OperatingSystem { get; }
    }
    public class Computer<T> : IHasOperatingSystem<T> where T : IOperatingSystem
    {
        public T OperatingSystem { get { ... } }
    }
