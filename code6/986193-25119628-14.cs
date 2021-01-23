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
          if(value != null)
             _viewableObject.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChanged)
          OnPropertyChanged("ViewableObject");
         }
    } 
