    public class PagedData<T>
    {
        [JsonNameBasedOnItemClassName]
        public IEnumerable<T> Data { get; private set; }
        public int Count { get; private set; }
        public int CurrentPage { get; private set; }
        public int Offset { get; private set; }
        public int RowsPerPage { get; private set; }
        public int? PreviousPage { get; private set; }
        public int? NextPage { get; private set; }
    }
