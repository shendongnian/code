    public async Task<IHttpActionResult> Get([FromUri] ListSelectionOptionsWithFilter options)
    {
       //query something
    }
    
    public class ListSelectionOptionsWithFilter
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public List<ListSortOption> Sort { get; set; }
        public ListFilterOptions Filter { get; set; }
    }
    
    public class ListFilterOptions
    {
        public string Logic { get; set; }
        public List<ListFilterOption> Filters { get; set; }
    }
    
    public class ListFilterOption
    {
        public string Field { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
    }
    
    public class ListSortOption
    {
        public string Field { get; set; }
        public string Dir { get; set; }
    }
