    private List<Image> _images = new List<Image>();
    private void Image_Loaded(object sender, RoutedEventArgs e)
    {
        _images.Add(sender as Image);
    }
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        base.OnNavigatedFrom(e);
        foreach(var img in _images)
        {
            img.Source = null;
        }
    }
