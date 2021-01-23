    private ICommand scrollCommand;
    public ICommand ScrollCommand
    {
    	get { return scrollCommand ?? (scrollCommand = new RelayCommand(Scroll)); }
    }
    
    private void Scroll(object parameter)
    {
    	ScrollChangedEventArgs scrollChangedEventArgs = parameter as ScrollChangedEventArgs;
    	if (scrollChangedEventArgs != null)
    	{
    		
    	}
    }
