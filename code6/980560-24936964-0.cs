    using (ImageFactory imageFactory = new ImageFactory())
    {
        // Load, resize, set the quality and save an image.
        imageFactory.Load(@"C:\a.jpg")
                    .Resize(new Size(50, 100))
                    .Quality(90)
                    .Save(@"C:\myimage.jpeg);
    }
