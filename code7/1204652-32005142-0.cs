    private ObservableCollection<Line> _unfilteredList;
    public ObservableCollection<Line> UnfilteredList 
    {
        get { return _unfilteredList; }
        private set
        {
            _unfilteredList = value;
            UpdateList();
        }
    }
    
    private List<Line> _filteredList; 
    public List<Line> FilteredList 
    {
        get 
        {
            return _filteredList;
        }
        private set
        {
            _filteredList = value;
            RaisePropertyChanged();
        }
    }
    
    private void UpdateList()
    {
        if (UnfilteredList != null)
        {
            FilteredList = null;
            FilteredList = UnfilteredList.Where(x=> x.IsItem).ToList();
        }
    }
