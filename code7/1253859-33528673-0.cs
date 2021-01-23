    public RelayCommand MyCommand 
    { 
      get; 
      private set; 
    } 
      
    public MainViewModel() 
    { 
      MyCommand = new RelayCommand( 
        ExecuteMyCommand, 
        () => _canExecuteMyCommand); 
    } 
      
    private void ExecuteMyCommand() 
    { 
      // Do something 
    }
