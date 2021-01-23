    var bitmap = new BitmapImage(new Uri("I:/image.jpg"));
    foreach (string s in Directory.GetDirectories("I:/"))
    {
        var sp = new StackPanel();
        sp.Children.Add(new Image { Source = bitmap });
        sp.Children.Add(new TextBlock { Text = s });
    }
