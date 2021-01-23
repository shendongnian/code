    ICollectionView MyCollection { get; private set; }
    public void LoadData()
    {
        var myObservable = //... load/create list
        MyCollection = CollectionViewSource.GetDefaultView(myObservable);
        MyCollection.Filter = item => ((TypeOfItem)item).Name = "bob";
    }
