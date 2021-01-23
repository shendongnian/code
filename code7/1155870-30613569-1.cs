    using (var graphics = System.Drawing.Graphics.FromHwnd(IntPtr.Zero))
    {
        return new System.Drawing.Rectangle(
          (int)(leftTopPoint.X * graphics.DpiX / 96.0),
          (int)(leftTopPoint.Y * graphics.DpiY / 96.0), 
          (int)(PreviewCanvas.ActualWidth * graphics.DpiX / 96.0),
          (int)(PreviewCanvas.ActualHeight * graphics.DpiY / 96.0)
         );
    }
