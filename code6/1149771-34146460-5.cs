    /// <summary>
    /// A singleton dependency
    /// </summary>
    public interface ISingletonDependency
    {
        string Dependency { get; }
    }
    public class SingletonDependency : ISingletonDependency
    {
        public SingletonDependency()
        {
            Dependency = Guid.NewGuid().ToString();
        }
        public string Dependency { get; }
    }
    /// <summary>
    /// A per call dependency.
    /// </summary>
    public interface IScopedDependency
    {
        string Dependency { get; }
    }
    public class ScopedDependency : IScopedDependency
    {
        public ScopedDependency()
        {
            Dependency = Guid.NewGuid().ToString();
        }
        public string Dependency { get;  }
    }
