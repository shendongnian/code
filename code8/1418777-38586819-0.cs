    public event PropertyChangedEventHandler PropertyChanged;
    protected void raisePropertyChanged(params string[] args)
    {
    	var handler = PropertyChanged;
    	if (handler != null)
    	{
    		foreach (var arg in args)
    		{
    			handler(this, new PropertyChangedEventArgs(arg));
    		}
    	}
    }
