    public class KendoQuery
    {
        List<SortTerm> sort;
        public List<SortTerm> Sort {
             get {
                 // Handles deserialising the SortJson value 
                 if(sort == null)
                     sort = ServiceStack.JsonSerializer.DeserializeFromString<List<SortTerm>>(SortJson);
                 return sort;
             }
        }
 
        public string SortJson { get; set; } 
        public int Skip { get; set; }
        public int Take { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
