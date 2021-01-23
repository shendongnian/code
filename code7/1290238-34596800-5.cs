    public class SearchVm
    {
        public List<SelectListItem> Operators { set; get; } 
        public List<SearchViewModel> Filters { set; get; }
    }
    public class SearchViewModel
    {
        //Property has a property called "SqlColumnName"
        public Property Property { get; set; }
        public SearchOperator Operator { get; set; }
        public string Value { get; set; }
    }
