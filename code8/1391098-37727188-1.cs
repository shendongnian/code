    private ObservableCollection<ItemModel> _listOfItems;
    public ObservableCollection <ItemModel> ListOfItems {
        get { return _listOfItems ?? _listOfItems == new ObservableCollection<ItemModel>; }
        set {
            if(_listOfItems != value) {
                _listOfItems = value;
                SetPropertyChanged();
            }
        }
