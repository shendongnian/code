    public class SearchViewModel : ReactiveObject, IRoutableViewHost
    {
        public ReactiveList<SearchResults> SearchResults { get; set; }
 
        private string searchQuery;
        public string SearchQuery {
            get { return searchQuery; }
            set { this.RaiseAndSetIfChanged(ref searchQuery, value); }
        }
 
        public ReactiveCommand<List<SearchResults>> Search { get; set; }
 
        public ISearchService SearchService { get; set; }
    }
