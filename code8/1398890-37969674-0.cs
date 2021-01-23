    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Application.Current.Resuming += Application_Current_Resuming;
        }
        private async void Application_Current_Resuming(object sender, object e)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, new Windows.UI.Core.DispatchedHandler(() =>
            {
                // Your code here
            }));
        }
    }
