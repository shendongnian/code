    public string Top
    {
    	get { return _top; }
    	set
    	{
    		_top = value;
    		OnPropertyChanged(x=>x.Middle);
    		OnPropertyChanged(x=>x.Bottom);
    	}
    }
