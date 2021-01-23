    private async Task GetEventData()
    { 
        //...
    }
    
    public Main()
    {
      InitializeComponent();
    
      GetEventData()
          .ContinueWith(t => Environment.Exit(-1));
    }
