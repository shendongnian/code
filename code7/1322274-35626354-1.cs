    public ICollectionView MyView{ get; set; }
    //ctor
    public ParentViewModel()
    {
        //...
        ParentsCollection= new ObservableCollection<Parents>();
        MyView= CollectionViewSource.GetDefaultView(ParentsCollection);
        //...
    }
    <DataGrid ItemsSource="{Binding MyView}"/>
