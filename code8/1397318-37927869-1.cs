    public class MyUser { }
    public class MyItem { }
    
    // you cannot use it out of the box, because it's abstract,
    // i.e. only for what's intended [=implemented].
    public abstract class PaginatedData<T>
    {
        // abstract, so you don't forget to override it in ancestors
        public abstract IEnumerable<T> Data { get; }
        public int Count { get; }
        public int CurrentPage { get; }
        public int Offset { get; }
        public int RowsPerPage { get; }
        public int? PreviousPage { get; }
        public int? NextPage { get; }
    }
    
    // you specify class explicitly
    // name is clear,.. still not clearer than PaginatedData<MyUser> though
    public sealed class PaginatedUsers : PaginatedData<MyUser>
    {
        // explicit mapping - more agile than implicit name convension
        [JsonProperty("Users")]
        public override IEnumerable<MyUser> Data { get; }
    }
    
    public sealed class PaginatedItems : PaginatedData<MyItem>
    {
        [JsonProperty("Items")]
        public override IEnumerable<MyItem> Data { get; }
    }
