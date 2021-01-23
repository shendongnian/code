    private string _tb;
    public string Tb
    {
    	get { return _tb; }
    	set
    	{
    		if(Equals(value, _tb))
    			return;
    			
    		_tb = value;
    		OnPropertyChanged();
    	}
    }
