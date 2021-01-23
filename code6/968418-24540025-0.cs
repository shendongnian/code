    public interface IVersion<T>
    {
        IVersionManager<T> Parent { get; }
        // various other methods
    }
    
    public interface IVersionManager<T>
    {
        IReadOnlyList<IVersion<T>> Versions { get; }
        IVersion<T> Current { get; }
        void AddVersion(IVersion<T> version);
        // various other methods
    }
