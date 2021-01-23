    // Define other methods and classes here
    public interface IVersion<T> where T:IVersion<T>   // <----- add restriction here
    {
        IVersionManager<T> Parent { get; }  // <--- change generic type here
        // various other methods
    }
    
    public interface IVersionManager<T> where T : IVersion<T>
    {
        IReadOnlyList<T> Versions { get; }  
        T Current { get; }
        void AddVersion(T version);
        // various other methods
    }
