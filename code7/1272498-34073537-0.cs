    public ICommand SearchCommand { get; protected set; }
    // Constructor
    public MyViewModel()
    {
        // DelegateCommand.FromAsyncHandler is from Prism Framework, but you can use
        // whatever your MVVM framework offers for async commands
        SearchCommand = DelegateCommand.FromAsyncHandler(DoSearch);
    }
    public async Task DoSearch() 
    {
        var result = await _listOfStuff.Where(x => x.Contains(SearchText)).ToListAsync();
        FilteredList = new Collection<string>(result);
    }
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
        get 
        { 
            return _searchText;
        }
        set
        {
            if (value != _searchText)
            {
                _searchText = value;
                OnPropertyChanged("SearchText");
            }
        }
    }
