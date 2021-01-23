    var bitmap = new RenderTargetBitmap(
        (int)grid2.ActualWidth, (int)grid2.ActualHeight, 96, 96, PixelFormats.Default);
    bitmap.Render(grid2);
    var encoder = new PngBitmapEncoder();
    encoder.Frames.Add(BitmapFrame.Create(bitmap));
    using (var stream = new FileStream("test.png", FileMode.Create))
    {
        encoder.Save(stream);
    }
