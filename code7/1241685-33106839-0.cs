    class ViewModelDefault : INotifyPropertyChanged
    {
    	// Bound to your textbox
    	public string TextboxProperty { get; set;}
    	
    	// Instantiate modellayer in viewmodel
    	private ModelClass _modelClass = new ModelClass();
    	
    	// RelayCommand property -> bound to button on viewmodel
    	// Will execute method "ExecuteCommand" that contains a call to a method in the ModelClass
    	public ICommand ExecuteModelMethod 
    	{ 
    		get {
    		RelayCommand relayCommand = new RelayCommand(ExecuteCommand); 
    		return relayCommand; 
    		} 
    	}
    	
    	// Method that the RelayCommand will execute.
    	private void ExecuteCommand() 
    	{
    		_modelClass.SaveTextInTextfile(TextboxProperty);
    	}
    	
    	...
    }
