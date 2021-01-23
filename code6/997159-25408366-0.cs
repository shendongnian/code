    private bool _isVisible = true;
    public bool IsVisible
    {
        get { return _isVisible; }
        set
    	{
    		if (value != _isVisible)
    		{
    			_isVisible = value; 
    			
    			this.RaisePropertyChanged("IsVisible");
    		}
    	}
    }
