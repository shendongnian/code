    public void ConvertToBitmapSource(UIElement element)
    {
        var target = new RenderTargetBitmap(
            (int)element.RenderSize.Width, (int)element.RenderSize.Height,
            96, 96, PixelFormats.Pbgra32);
        target.Render(element);
    
        var encoder = new PngBitmapEncoder();
        var outputFrame = BitmapFrame.Create(target);
        encoder.Frames.Add(outputFrame);
    
        using (var file = File.OpenWrite("TestImage.png"))
        {
            encoder.Save(file);
        }
    }
