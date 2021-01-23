    public class SearchViewModel
    {
        public SearchViewModel()
        {
            this.SearchObjectTypes = new List<SelectListItem>();
        }
    
        public IList<SelectListItem> SearchObjectTypes { get; set; }
    }
