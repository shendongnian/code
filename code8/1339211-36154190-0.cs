    ObservableCollection<IMailCount> _collection = new ObservableCollection<IMailCount>();
    public ObservableCollection<IMailCount> Collection
    {
        get { return _collection; }
        set
        {
            _collection = value;
            OnPropertyChanged();
        }
    }
