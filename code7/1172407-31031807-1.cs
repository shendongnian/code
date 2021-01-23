    public GeneralDataGridViewModel() : base()
    {
        _collection = new ObservableCollection<ItemViewModel>();
        _collection.Add(new ItemViewModel(new Model("code1")));
        _collection.Add(new ItemViewModel(new Model("code2")));
        _collection.Add(new ItemViewModel(new Model("code3")));
        _collection.Add(new ItemViewModel(new Model("code4")));
    }
