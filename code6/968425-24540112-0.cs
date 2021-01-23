    public interface IVersion<T>
    {
        IVersionManager<IVersion<T>, T> Parent { get; }
    }
    public interface IVersionManager<T, T2> where T : IVersion<T2>
    {
        IReadOnlyList<T2> Versions { get; }
        T2 Current { get; }
        void AddVersion(T2 version);
        // various other methods
    }
