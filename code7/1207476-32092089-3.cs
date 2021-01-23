    public ICommand MyCommand
    {
    	get
    	{
    		return new RelayCommand(() =>
    		{
    			doSomething();
    		});
    	}
    }
