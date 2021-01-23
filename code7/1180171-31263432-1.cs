    ImageBrush brush1 = new ImageBrush();    
    brush1.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/emptyseat.jpg"));
    btn.Tag = "emptyseat.jpg";
    btn.Background = brush1;
    public void OnClick(object sender, RoutedEventArgs e)
    {
        var btn = (Button)sender;
        string name = btn.Tag;      
    }
