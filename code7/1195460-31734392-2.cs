    public TermsAndConditionsViewModel()
       {
           NextCommand = new Command(ExecuteNextCommand,CanExecuteNextCommand);
           OnCheckBoxTapChanged = new Command(CheckBoxTapped);
       }
    
    
    private bool _isChecked;
    public bool IsChecked
    {
        get { return _isChecked;}
        set
        {
             _isChecked = value;
    	NextCommand.ChangeCanExecute(); //this will actually notify the command to enable/disable
            RaisePropertyChanged("IsChecked");
        }
    }
    
    
    public Command NextCommand {get;set;} // this type is available in Xamarin.Forms library
    private bool CanExecuteNextCommand()
    {
    	return IsChecked;
    }
    private void ExecuteNextCommand()
    {
    	// your execution when the button is pressed 	
    }
  
