    var encoder = new PngBitmapEncoder();
    encoder.Frames.Add(BitmapFrame.Create((BitmapSource)_window.Icon));
    using (var stream = File.OpenWrite("icon.png")) encoder.Save(stream);
    var bitmap = (System.Drawing.Bitmap)System.Drawing.Image.FromFile("icon.png");
    var icon = System.Drawing.Icon.FromHandle(bitmap.GetHicon());
