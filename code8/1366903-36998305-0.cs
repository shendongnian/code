    public static void Save(BitmapImage srcBitmap, Int32Rect srcRegion, Rect destRegion)
    {
        var cropped = new CroppedBitmap(srcBitmap, srcRegion);
    
        var drawingVisual = new DrawingVisual();
        
        //Here is the changes:
        var scale = 256.0 / srcRegion.Width;
        var transform = new ScaleTransform(scale, scale);
        //
        using (DrawingContext drawingContext = drawingVisual.RenderOpen())
        {
            //Here is the changes:
            drawingContext.DrawImage(new TransformedBitmap(cropped, transform), destRegion);
            //
        }
    
        var bmp = new RenderTargetBitmap(256, 256, 96, 96, PixelFormats.Pbgra32);
    
        bmp.Render(drawingVisual);
    
        var bitmapEncoder = new PngBitmapEncoder();
    
        bitmapEncoder.Frames.Add(BitmapFrame.Create(bmp));
    
        using (var filestream = new FileStream(path, FileMode.Create))
        {
            bitmapEncoder.Save(filestream);
        }
    }
