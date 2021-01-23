    private async TaskGetEventData()
    { 
        //...
    }
    
    public Main()
    {
      InitializeComponent();
    
      GetEventData()
          .ContinueWith(t => Environment.Exit(-1));
    }
