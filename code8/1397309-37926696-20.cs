    [JsonConverter(typeof(PagedDataConverter))]
    public class PagedData<T>
    {
        public string DataPropertyName { get; set; }
        public IEnumerable<T> Data { get; set; }
        ...
    }
