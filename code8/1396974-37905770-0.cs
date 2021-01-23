    ...
    private ICollectionView _dataItems;
    public ICollectionView DataItems { 
      get
      {
        return this._dataItems;
      }
      private set 
      {
        this._dataItems = value;
        this.OnPropertyChanged("DataItems"); // Update the method name to whatever you have
      }
    ...
