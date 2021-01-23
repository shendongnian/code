    public partial class YourWindow : Window
    {
        private readonly App app = Application.Current as App;
        public YourWindow()
        {
            this.InitializeComponent();
            // Handle our PubSub subscription
            app.EventService.GetEvent<SaveEnabledEvent>().Subscribe(HandleSaveChange);
        }
        private void HandleSaveChange(UserAccountsStatusHandler status)
        {
            if (status.IsSaveEnabled)
            {
                // Do stuff
            }
        }
    }
