    public partial class YourWindow : Window
    {
        private readonly App app = Application.Current as App;
        public YourWindow()
        {
            this.InitializeComponent();
            // Handle our PubSub subscription
            app.EventService.GetEvent<SaveEnabledEvent>().Subscribe(() =>
            {
                if (status.IsSaveEnabled)
                {
                    // Do stuff
                }
            });
        }
    }
