    public FramePage()
        {
            this.InitializeComponent();
            mainFrame.Navigate(typeof(Frame1));
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame.CanGoBack)
                mainFrame.GoBack();
        }
        private void next_Click(object sender, RoutedEventArgs e)
        {
            Type current = mainFrame.SourcePageType;
           
            if (current.Name == "Frame1")
                mainFrame.Navigate(typeof(Frame2));
            if (current.Name == "Frame2")
                mainFrame.Navigate(typeof(Frame3));
        }
