    public sealed partial class MyControl : UserControl
    {
        public delegate void MyEventHandler(object source, EventArgs e);
        public event MyEventHandler OnNavigateParentReady;
        public MyControl()
        {
            this.InitializeComponent();
        }
        private void WifiBtn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
        }
        public ToggleButton WifiButton
        {
            get
            {
                return WifiBtn;
            }
        }
        private void testbtn_Click(object sender, RoutedEventArgs e)
        {
            OnNavigateParentReady(this, null);
        }
    }
