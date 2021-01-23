    private void Button_Click(object sender, RoutedEventArgs e)
    {
        App.Current.Resources["SystemControlBackgroundBaseLowBrush"] = new SolidColorBrush(Colors.Yellow); // background
        App.Current.Resources["SystemControlDisabledBaseMediumLowBrush"] = new SolidColorBrush(Colors.Red); // content
        App.Current.Resources["SystemControlDisabledTransparentBrush"] = new SolidColorBrush(Colors.Green); // border
    }
