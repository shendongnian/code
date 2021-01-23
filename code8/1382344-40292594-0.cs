    public override void ViewDidLoad()
    {
       base.ViewDidLoad();
       Initialization = InitializeAsync();
      
       OtherStuff();
    }
    public Task Initialization { get; private set; }
    private async Task InitializeAsync()
    {
        // Do our own initialization (synchronous or asynchronous).
        await Task.Delay(100);
    }
