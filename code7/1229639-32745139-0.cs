    public class PageResult<T> where T : class
    {
        public PageResult();
        public IEnumerable<T> Items { get; set; }
        public int PageSize { get; set; }
        
        public int Page {get; set;}     
        public int Total { get; set; }
    }
