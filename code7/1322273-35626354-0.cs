    public ICollectionView ViewSource { get; set; }
    //ctor
    public ParentViewModel()
    {
        //...
        ParentsCollection= new ObservableCollection<Parents>();
        ViewSource = CollectionViewSource.GetDefaultView(ParentsCollection);
        //...
    }
