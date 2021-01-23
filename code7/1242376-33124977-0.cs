    class ViewModelDefault : INotifyPropertyChanged
    {
    	public string TextProperty { get; set;}
    	
    	public ICommand ButtonProperty 
    	{ 
    		get {
    			RelayCommand relayCommand = new RelayCommand(ExecuteCommand); 
    			return relayCommand; 
    		} 
    	}
    	
    	private void ExecuteCommand() 
    	{
    		HandlerClass handler = new HandlerClass();
    		handler.SaveTextInTextfile(TextboxProperty);
    	}
    	
    	...
    }
