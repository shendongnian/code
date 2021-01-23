    private ICollectionView tyreCollectionView;    
    public ICollectionView TyreCollectionView
    {
    	get
    	{
    		return this.tyreCollectionView;
    	}
    	set
    	{
    		this.tyreCollectionView = value; NotifyPropertyChanged( "TyreCollectionView" );
    	}
    }
    
    #region INotifyPropertyChanged Members
    public event PropertyChangedEventHandler PropertyChanged;
    #endregion
    protected void NotifyPropertyChanged( String info )
    {
    	if ( PropertyChanged != null )
    	{
    		PropertyChanged( this, new PropertyChangedEventArgs( info ) );
    	}
    }
