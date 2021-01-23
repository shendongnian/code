    public interface IHashStorage<T>
    {
        float InitialLoadFactor { get; }
        int InitialCapacity { get; }
    }
    public class HashStorageBase<T> : IHashStorage<T>
    {
        private readonly float _initialLoadFactor = 0.7f;
        private readonly int _initialCapacity = 149;
        public float InitialLoadFactor
        {
            get { return _initialLoadFactor; }
        }
        public int InitialCapacity
        {
            get { return _initialCapacity; }
        }
    }
    public class HashStorage1<T> : HashStorageBase<T>
    {
        ...
    }
