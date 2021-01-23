    public class MyUser { }
    public class MyItem { }
    
    public abstract class PaginatedData<T>
    {
        public abstract IEnumerable<T> Data { get; }
        public int Count { get; }
        public int CurrentPage { get; }
        public int Offset { get; }
        public int RowsPerPage { get; }
        public int? PreviousPage { get; }
        public int? NextPage { get; }
    }
    
    public sealed class PaginatedUsers : PaginatedData<MyUser>
    {
        [JsonProperty("Users")]
        public override IEnumerable<MyUser> Data { get; }
    }
    
    public sealed class PaginatedItems : PaginatedData<MyItem>
    {
        [JsonProperty("Items")]
        public override IEnumerable<MyItem> Data { get; }
    }
