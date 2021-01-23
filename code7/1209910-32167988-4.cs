    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            var dispatcher = Application.Current.Dispatcher;
            var cleanupTask = Task.Run(
                async () =>
                {
                    dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate {StatusMessage.Text = "Stopping running backtest..."; }));
                    await Task.Delay(2000);
                    dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { StatusMessage.Text = "Disposing backtest engine..."; }));
                    await Task.Delay(2000);
                });
            while (!cleanupTask.IsCompleted)
            {
                dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
            }
        }
    }
