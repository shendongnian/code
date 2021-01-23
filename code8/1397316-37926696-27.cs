    [JsonConverter(typeof(PagedDataConverter))]
    public class PagedData<T>
    {
        private string DataPropertyName { get; set; }
        public IEnumerable<T> Data { get; private set; }
        ...
    }
