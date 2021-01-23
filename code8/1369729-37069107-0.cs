    private ObservableCollection<bool> _Collection
        = new ObservableCollection<bool>(new[] { false, false, false, false, false, false });
    public ObservableCollection<bool> Collection
    {
        get { return _Collection; }
        set { _Collection = value; OnPropertyChanged("Collection"); }
    }
