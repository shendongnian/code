    public interface IVersion<T> where T : IVersion<T>
    {
        IVersionManager<T> Parent { get; }
        // various other methods
    }
