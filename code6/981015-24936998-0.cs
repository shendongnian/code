    System.Drawing.Image source = System.Drawing.Image.FromFile(@"Z:\Temp\temp.bmp");
    System.Drawing.Image destination = new System.Drawing.Bitmap(128, 128);
    using (var g = Graphics.FromImage(destination))
    {
        g.InterpolationMode = InterpolationMode.HighQualityBilinear;
        g.DrawImage(source, new System.Drawing.Rectangle(0,0,128,128), new System.Drawing.Rectangle(0, 0,source.Width, source.Height), GraphicsUnit.Pixel);
    }
    destination.Save(@"Z:\Temp\outpt.png", ImageFormat.Png);
