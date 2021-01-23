    /// <summary>
    /// Gets a render of the current UIElement
    /// </summary>
    /// <param name="source">UIElement to screenshot</param>
    /// <param name="dpi">The DPI of the source.</param>
    /// <returns>An ImageSource</returns>
    public static RenderTargetBitmap GetRender(this UIElement source, double dpi)
    {
        Rect bounds = VisualTreeHelper.GetDescendantBounds(source);
        var scale = dpi / 96.0;
        var width = (bounds.Width + bounds.X) * scale;
        var height = (bounds.Height + bounds.Y) * scale;
        #region If no bounds
        if (bounds.IsEmpty)
        {
            var control = source as Control;
            if (control != null)
            {
                width = control.ActualWidth * scale;
                height = control.ActualHeight * scale;
            }
            bounds = new Rect(new System.Windows.Point(0d, 0d), 
                              new System.Windows.Point(width, height));
        }
        #endregion
        var roundWidth = (int)Math.Round(width, MidpointRounding.AwayFromZero);
        var roundHeight = (int)Math.Round(height, MidpointRounding.AwayFromZero);
        var rtb = new RenderTargetBitmap(roundWidth, roundHeight, dpi, dpi, 
                                         PixelFormats.Pbgra32);
        DrawingVisual dv = new DrawingVisual();
        using (DrawingContext ctx = dv.RenderOpen())
        {
            VisualBrush vb = new VisualBrush(source);
            var locationRect = new System.Windows.Point(bounds.X, bounds.Y);
            var sizeRect = new System.Windows.Size(bounds.Width, bounds.Height);
            ctx.DrawRectangle(vb, null, new Rect(locationRect, sizeRect));
        }
        rtb.Render(dv);
        return (RenderTargetBitmap)rtb.GetAsFrozen();
    }
