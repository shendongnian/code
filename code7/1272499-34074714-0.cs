    private Collection<string> _listOfStuff;
    private Collection<string> _filteredList;
    public Collection<string> FilteredList
    {
        get
        {         
                return _filteredList;
        }
        set
        {
            if (value != _filteredList)
            {
                _filteredList = value;
                OnPropertyChanged("FilteredList");
            }
        }
    }
    private string _searchText;
    public string SearchText
    {
        get { return _searchText; }
        set
        {
            if (value != _searchText)
            {
                _searchText = value;
                OnPropertyChanged("SearchText");
                FilteredList = new Collection<string>(_listOfStuff.Where(x => x.Contains(SearchText)));
            }
        }
    }
