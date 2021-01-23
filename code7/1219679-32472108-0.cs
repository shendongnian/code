    private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Resources["DynamicBrush"] = new SolidColorBrush(Colors.Red);
            this.Foreground = App.Current.Resources["DynamicBrush"] as SolidColorBrush;
        }
    
