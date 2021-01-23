    private ObservableColletion<ObservableObject> _myCollection;
    public ObservableCollection<ObservableObject> MyCollection
    {
      get
      {
        return _myCollection;
      }
      set
      {
        SetProperty(ref _myCollection,new ObservableCollection<ObservableObject>(value));
      }
    } 
