        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new List<String> { "Item 1", "Item 2", "Item 3" };
        }
        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            var fe = sender as FrameworkElement;
            var value = fe.DataContext.ToString();
            await new MessageDialog(value).ShowAsync();
        }
        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var fe = sender as FrameworkElement;
            var menu = Flyout.GetAttachedFlyout(fe);
            menu.ShowAt(fe);
        }
    }
