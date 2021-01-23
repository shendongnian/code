    Border border = new Border();
    border.Width = 200d;
    border.Height = 200d;
    border.CornerRadius = new CornerRadius(0, 100, 0, 100);
    border.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
    border.BorderThickness = new Thickness(2.5d);
           
    ImageBrush img = new ImageBrush();
    img.ImageSource = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("https://bushrasbrilliantblog.files.wordpress.com/2014/10/placid_nature.jpg", UriKind.RelativeOrAbsolute));
    img.Stretch = Stretch.Fill;
    border.Background = img;
    LayoutRoot.Children.Add(border);
