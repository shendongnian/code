    // this is just POCO
    public class SearchParameters
    {
        public string SomeString { get; set; }
        public DateTime? SomeDate { get; set; }
        public bool? SomeBool { get; set; }
        // etc...
    }
    
    IEnumerable<SomeEntitites> GetSomeEntitites(SearchParameters searchParameters);
