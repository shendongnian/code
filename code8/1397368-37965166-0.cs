    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void txt1_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            // Right Arrow key Pressed
            if (e.Key == Windows.System.VirtualKey.Right)
            {
                // Do something
                Debug.WriteLine(e.Key.ToString());
                await new MessageDialog(e.Key.ToString()).ShowAsync();
            }
            // Other Keys Pressed
            await new MessageDialog(e.Key.ToString()).ShowAsync();
        }
