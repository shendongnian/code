    var bitmapImage = new BitmapImage(new Uri(@"pack://application:,,,/"
        + Assembly.GetExecutingAssembly().GetName().Name
        + ";component/"
        + "images/pp.png", UriKind.Absolute));
    var encoder = new PngBitmapEncoder();
    encoder.Frames.Add(BitmapFrame.Create((BitmapImage)bitmapImage));
    var stream = new MemoryStream();
    encoder.Save(stream);
    stream.Flush();
    var image = new System.Drawing.Bitmap(stream);
