    public void navigateMediaSelection(object sender, RoutedEventArgs e)
    {
        BBCodeBlock window = new BBCodeBlock();
        try
        {
            window.LinkNavigator.Navigate(new Uri("/Pages/MediaView/MovieView.xaml", UriKind.Relative), this);
        }
        catch (Exception error)
        {
            ModernDialog.ShowMessage(error.Message, FirstFloor.ModernUI.Resources.NavigationFailed, MessageBoxButton.OK);
        }
        
    }
