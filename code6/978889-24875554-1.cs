    var encoder = new PngBitmapEncoder();
    encoder.Frames.Add(BitmapFrame.Create((BitmapSource)_window.Icon));
    using (var stream = new MemoryStream()))
    {
        encoder.Save(stream);
        stream.Position = 0; // rewind the stream
        var bitmap = (System.Drawing.Bitmap)System.Drawing.Image.FromStream(stream);
        var icon = System.Drawing.Icon.FromHandle(bitmap.GetHicon());
    }
