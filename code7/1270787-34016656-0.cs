    private ObservableCollection<string> _ItemsList;
    public ObservableCollection<string> ItemsList
    {
      get
      {
         return _ItemsList;
      }
      set
      {
         _ItemsList = value;
         RaisePropertyChanged("ItemsList");
      }
    }
