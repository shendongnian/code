    public sealed partial class MainPage
    {
        private bool running;
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            running = true;
            // Start background thread
            Task.Run(
                async () =>
                {
                    int counter = 0;
                    while (running)
                    {
                        // UI updates must happen on the UI thread;
                        // we use the Dispatcher for this:
                        await Dispatcher.RunAsync(
                            CoreDispatcherPriority.Normal,
                            () => test.Text = counter.ToString());
                        await Task.Delay(1000);
                        ++counter;
                    }
                });
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            running = false;
        }
