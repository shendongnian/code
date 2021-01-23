    public class List<T> : IList<T>, System.Collections.IList, IReadOnlyList<T>
    {
        private const int _defaultCapacity = 4;
        private T[] _items;
        [ContractPublicPropertyName("Count")]
        private int _size;
