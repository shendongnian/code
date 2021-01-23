    String path = Directory.GetCurrentDirectory() + @"\Imports";
	var newSource = new List<Image>();
    foreach (String imgurl in Directory.GetFiles(path))
    {
        String filename = Path.GetFileName(imgurl);
        Uri uri = new Uri("ms-appx:///" + filename);
        var image = new Image
        {
            Source = new BitmapImage(uri)
        };
        // fv is my flipview
        newSource.Add(image);
    }
	fv.ItemsSource = newSource;
