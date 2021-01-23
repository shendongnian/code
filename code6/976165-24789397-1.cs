    public interface IHasOperatingSystem
    {
        IOperatingSystem OperatingSystem { get; }
    } 
    
    public class Computer<T> : IHasOperatingSystem where T : IOperatingSystem
    {
        // Explicit interface implementation...
        IHasOperatingSystem.OperatingSystem IOperatingSystem
        {
            // Delegate to the public property
            get { return OperatingSystem; }
        }
        public T OperatingSystem { get { ... } };
    }
