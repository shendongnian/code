    public MainWindow()
            {
                InitializeComponent();
                WhiteMaskCanvas.Visibility = Visibility.Collapsed;
            }
    private void SwitchOpacity_OnClick(object sender, RoutedEventArgs e)
            {
                WhiteMaskCanvas.Visibility = Visibility.Visible;
    
                int opacityVal = 0;
    
                Task.Factory.StartNew(() =>
                {
                //below same as code above
