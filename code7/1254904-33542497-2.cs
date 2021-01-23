    private bool _isAuth;
    public bool IsAuth
    {
    	get { return _isAuth; }
    	set { _isAuth = value; NotifyPropertyChanged( "IsAuth" ); }
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
