    private ObservableCollection<MyItem> _items;
    public ObservableCollection<MyItem> Items {
        get { return _items;}
        set 
        { 
            _items = value;
            OnPropertyChanged(()=> Items);
        }
    }
