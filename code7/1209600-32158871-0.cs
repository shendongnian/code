    foreach (string path in mapImagePaths) { // mapImagePaths: a list of map image names
      var b = new BitmapImage();
      b.BeginInit();
      b.UriSource = new Uri(path, UriKind.Relative); // or Absolute
      b.CacheOption = BitmapCacheOption.OnLoad; // maybe needed
      b.EndInit();
      var i = new Image { Source = b, Stretch = Stretch.Uniform };
      Grid.SetRow(i, /*the row index based on the coordinates*/);
      Grid.SetColumn(i, /*the column index based on the coordinates*/);
      mapGrid.Children.Add(i);
    }
