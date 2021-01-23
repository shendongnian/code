    private ObservableCollection<string> _listOStrings = new ObservableCollection<string>();
    public ObservableCollection<string> ListOStrings 
    {
        get
        {
            return _listOStrings;
        }
    
        set
        {
            _listOStrings = value;
            OnPropertyChanged("ListOStrings");
        }
    }
