    private SomeClass _viewableObject;
    public SomeClass ViewableObject
    {
         get
         {
          return _viewableObject;
         }
         set
         {
          _viewableObject = value;
          _viewableObject.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChanged)
          OnPropertyChanged("ViewableObject");
         }
    } 
