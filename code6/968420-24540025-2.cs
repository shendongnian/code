    public interface IVersion<T>
    {
        IVersionManager<T> Parent { get; }
        // various other methods
    }
    
    public interface IVersionManager<TVersion, T> 
        where TVersion : IVersion<T>
    {
        IReadOnlyList<TVersion> Versions { get; }
        TVersion Current { get; }
        void AddVersion(TVersion version);
        // various other methods
    }
