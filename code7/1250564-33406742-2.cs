    public int collectionCount;
    public int CollectionCount
    {
        get
        {
            return collectionCount;
        }
        set
        {
            collectionCount = value;
            RaisePropertyChanged("CollectionCount");
        }
    } 
