    String path = Directory.GetCurrentDirectory() + @"\Imports";
    foreach (String imgurl in Directory.GetFiles(path))
    {
        String filename = Path.GetFileName(imgurl);
        Uri uri = new Uri("ms-appx:///" + filename);
        var image = new Image
        {
            Source = new BitmapImage(uri)
        };
        // fv is my flipview
        fv.Items.Add(image);
    }
