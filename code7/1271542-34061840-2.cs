            public MainPage()
            {
                this.InitializeComponent();
            }
    
            private void Button_Click1(object sender, RoutedEventArgs e)
            {
                this.Frame.Navigate(typeof(PivotPage), "Item1");
            }
    
            private void Button_Click2(object sender, RoutedEventArgs e)
            {
                this.Frame.Navigate(typeof(PivotPage), "Item2");
            }
    
            private void Button_Click3(object sender, RoutedEventArgs e)
            {
                this.Frame.Navigate(typeof(PivotPage), "Item3");
            }
