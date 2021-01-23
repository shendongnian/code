    private DbSet _data;
    
    ICollectionView _collectionView;
    public ICollectionView CollectionView 
    {
    	get { return _collectionView; }
    	set
    	{
    		_collectionView = value;
    		RaisePropertyChanged("CollectionView");
    	}	
    }
