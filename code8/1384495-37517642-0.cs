    public class SearchResultRecord
    {
         // other entities here
         ...
         // nested list used to hold jagged array values
         public List<List<SearchResultRecord>> values { get; set; }
    }
