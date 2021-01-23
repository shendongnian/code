    public sealed partial class MainPage
    {
        private CancellationTokenSource cancellationTokenSource;
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            // Start background thread
            Task.Run(
                async () =>
                {
                    int counter = 0;
                    while (true)
                    {
                        if (token.IsCancellationRequested)
                        {
                            // Stop the loop; we're moving away from the page
                            break;
                        }
                        // UI updates must happen on the UI thread;
                        // we use the Dispatcher for this:
                        await Dispatcher.RunAsync(
                            CoreDispatcherPriority.Normal,
                            () => test.Text = counter.ToString());
                        await Task.Delay(1000, token);
                        ++counter;
                    }
                });
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }
    }
