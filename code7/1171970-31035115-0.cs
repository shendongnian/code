    [PropertyChanged.ImplementPropertyChanged]
    class SearchViewModel
    {
        private readonly string[] items;
        public string[] SearchResults { get; private set; }
        public bool IsSearchShown { get; set; }
        public string SearchText { get; set; }
        private void OnSearchTextChanged() 
        {
            UpdateSearchResults();
            IsSearchShown = true;
        }
        public string SelectedSearchItem { get; set; }
        private void OnSelectedSearchItemChanged()
        {
            SearchText = SelectedSearchItem;
            IsSearchShown = false;
        }
        private void UpdateSearchResults()
        {
            SearchResults = items.Where(item => item.StartsWith(SearchText)).ToArray();
        }
        public SearchViewModel(string[] items)
        {
            this.items = items;
            SearchResults = new string[0];
        }
    }
