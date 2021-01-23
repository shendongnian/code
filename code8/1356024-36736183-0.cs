    using (FileStream stream = File.OpenRead("foo.jpg"))
    using (Image image = new Image(stream))
    using (FileStream output = File.OpenWrite("bar.jpg"))
    {
        image.Resize(image.Width / 2, image.Height / 2)
             .Greyscale()
             .Save(output);
    }
