    private FrameworkElement originalSource;
    private void ChoiceA_Click(object sender, RoutedEventArgs e)
    {
        var itemdatacontext = originalSource.DataContext;
    }
    
    private void ListView_RightTapped(object sender, RightTappedRoutedEventArgs e)
    {
        originalSource = (FrameworkElement)e.OriginalSource;
    }
