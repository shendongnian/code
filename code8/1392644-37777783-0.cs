    public Task Initialization { get; }
    public string Value { get; private set { /* code to raise PropertyChanged */ } }
    public App()
    {
      this.InitializeComponent();
      this.Suspending += OnSuspending;
      CoinPriceBackend CP = new CoinPriceBackend();
      Value = "Loading..."; // Initialize to loading state.
      Initialization = InitializeAsync();
    }
    private async Task InitializeAsync()
    {
      try
      {
        string response = await GetFromAPI();
        ...
        Value = response; // Update data-bound value.
      }
      catch (Exception ex)
      {
        ... // Display to user or something...
      }
    }
