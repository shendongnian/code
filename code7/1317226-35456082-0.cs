    private void btn_Click(object sender, RoutedEventArgs e)
    {
        btn.Content = new Image
        {              
            Source = new BitmapImage(new Uri("/WpfApplication1;component/image/add.jpg", UriKind.Relative)),
            VerticalAlignment = VerticalAlignment.Center,
            Stretch = Stretch.Fill,
            Height = 256,
            Width = 256
        };
    }
