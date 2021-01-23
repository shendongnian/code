    private ICommand ThumbDragDeltaCommand { get; set;}
    public MainViewModel() //Constructor
    {
        ThumbDragDeltaCommand = new DelegateCommand(x => 
        {
            //EventHandler
            //Do stuff...
        }
    }
