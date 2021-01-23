    public static BitmapSource CreateBitmap(int width, int height, double dpi,
        IEnumerable<Action<DrawingContext>> renderActions)
    {
        DrawingVisual drawingVisual = new DrawingVisual();
        using (DrawingContext drawingContext = drawingVisual.RenderOpen())
        {
            foreach (var render in renderActions)
                render(drawingContext);
        }
        RenderTargetBitmap bitmap = new RenderTargetBitmap(
            width, height, dpi, dpi, PixelFormats.Default);
        bitmap.Render(drawingVisual);
        return bitmap;
    }
