    public bool IsShowHideVisible
    {
    	get { return isShowHideVisible; }
    	set
    	{
    		if(isShowHideVisible!=value)
    		{
    			isShowHideVisible = value;
    			OnPropertyChanged("IsShowHideVisible");
    		}
    	}
    }
