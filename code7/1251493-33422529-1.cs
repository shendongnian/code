    public event EventHandler<RoutedEventArgs> ImageClicked;
    private void OnClicked(object sender, RoutedEventArgs e)
    {
        if (ImageClicked != null)
            ImageClicked(sender, e);
    }
