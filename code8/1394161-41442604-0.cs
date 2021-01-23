    var newWidth = 100;
    using (var collection = new MagickImageCollection(new FileInfo(@"C:\test.gif")))
    {
        collection.Coalesce();
        foreach (var image in collection)
        {
            image.Resize(newWidth, 0);
        }
        collection.Write(@"c:\resized.gif");
    }
