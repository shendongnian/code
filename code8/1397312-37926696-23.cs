    public class PagedData<T>
    {
        [JsonPropertyNameBasedOnItemClass]
        public IEnumerable<T> Data { get; private set; }
        ...
    }
