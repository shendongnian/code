    public class PagedData<T>
    {
        [JsonNameBasedOnItemClassName]
        public IEnumerable<T> Data { get; private set; }
        ...
    }
