    for(int i = 0; i < 8; i++)
    {
      Image a = new Image();
      BitmapImage b = new BitmapImage();
      b.BeginInit();
      b.UriSource = new Uri("path");
      b.EndInit();
      a.Source = b;
      a.Width = 50;
      a.Height = 50;
      images.Add(a);
    }
