    private static void ProcessImages()
    {
        (* load images *)
        var img1 = AForge.Imaging.Image.FromFile(@"compare1.jpg");
        var img2 = AForge.Imaging.Image.FromFile(@"compare2.jpg");
        
        (* calculate absolute difference *)
        var difference = new AForge.Imaging.Filters.Difference(img1)
                         .Apply(img2);
        (* create and initialize the blob counter *)
        var bc = new AForge.Imaging.BlobCounter();
        bc.FilterBlobs = true;
        bc.MinWidth = 5;
        bc.MinHeight = 5;
        bc.BackgroundThreshold = Color.FromArgb(20, 20, 20);
        (* find blobs *)
        bc.ProcessImage(difference);
        (* draw result *)
        BitmapData data = img2.LockBits(
           new Rectangle(0, 0, img2.Width, img2.Height),
              ImageLockMode.ReadWrite, img2.PixelFormat);
        foreach (var rc in bc.GetObjectsRectangles())
            AForge.Imaging.Drawing.FillRectangle(data, rc, Color.FromArgb(128,Color.Red));
        img2.UnlockBits(data);
        img2.Save(@"compareResult.jpg");
    }
