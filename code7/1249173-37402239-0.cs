    using (FileStream stream = File.OpenRead("foo.jpg"))
    using (FileStream output = File.OpenWrite("bar.jpg"))
    using (Image image = new Image(stream))
    {
        image.Resize(image.Width / 2, image.Height / 2)
             .Greyscale()
             .Save(output);
    }
