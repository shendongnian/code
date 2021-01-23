       public MainPage()
        {
            this.InitializeComponent();
            RequestedTheme=ElementTheme.Light;
        }
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            RequestedTheme = ElementTheme.Dark;
        }
